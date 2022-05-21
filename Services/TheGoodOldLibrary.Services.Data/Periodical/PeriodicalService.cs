namespace TheGoodOldLibrary.Services.Data.Periodical
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.Periodical;

    public class PeriodicalService : IPeriodicalService
    {
        private readonly IDeletableEntityRepository<Periodical> periodicalRepository;

        public PeriodicalService(IDeletableEntityRepository<Periodical> periodicalRepository)
        {
            this.periodicalRepository = periodicalRepository;
        }

        public async Task CreateAsync(CreatePeridiocalViewModel model)
        {
            var periodical = new Periodical
            {
                Name = model.Name,
                TypeId = model.TypeId,
                ImageUrl = model.Image,
            };

            await this.periodicalRepository.AddAsync(periodical);
            await this.periodicalRepository.SaveChangesAsync();
        }

        public IEnumerable<PeriodicalInListViewModel> GetAll<T>(int page, int itemsPerPage = 5)
        {
            var periodical = this.periodicalRepository.AllAsNoTracking()
               .OrderBy(x => x.Name)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(x => new PeriodicalInListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.ImageUrl,
                    TypeName = x.Type.Name,
                }).ToList();

            return periodical;
        }

        public int GetCount()
        {
           return this.periodicalRepository.AllAsNoTracking().Count();
        }
    }
}
