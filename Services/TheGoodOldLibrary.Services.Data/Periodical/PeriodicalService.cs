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
                AuthorId = model.AuthorId,
                ImageUrl = model.Image,
                PeriodicalCount = model.PeriodicalCount,
            };

            await this.periodicalRepository.AddAsync(periodical);
            await this.periodicalRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(PeriodicalInListViewModel model, int id)
        {
            var periodical = this.periodicalRepository.AllAsNoTracking().FirstOrDefault(s => s.Id == id);
            periodical.Name = model.Name;
            periodical.ImageUrl = model.ImageUrl;
            periodical.PeriodicalCount = model.PeriodicalCount;
            periodical.TypeId = model.TypeId;
            periodical.AuthorId = model.AuthorId;

            this.periodicalRepository.Update(periodical);
            await this.periodicalRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var periodical = this.periodicalRepository.AllAsNoTracking().FirstOrDefault(s => s.Id == id);
            this.periodicalRepository.Delete(periodical);
            await this.periodicalRepository.SaveChangesAsync();
        }

        public IEnumerable<PeriodicalInListViewModel> GetAll<T>(int page, int itemsPerPage = 5)
        {
            return this.periodicalRepository.AllAsNoTracking()
               .OrderBy(x => x.Name)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(x => new PeriodicalInListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    TypeName = x.Type.Name,
                    TypeId = x.TypeId,
                    PeriodicalCount = x.PeriodicalCount,
                }).ToList();
        }

        public PeriodicalInListViewModel GetById<T>(int id)
        {
            var periodical = this.periodicalRepository.AllAsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new PeriodicalInListViewModel
                {
                    Id = s.Id,
                    ImageUrl = s.ImageUrl,
                    Name = s.Name,
                    TypeName = s.Type.Name,
                    PeriodicalCount = s.PeriodicalCount,
                }).FirstOrDefault();

            return periodical;
        }

        public int GetCount()
        {
            return this.periodicalRepository.AllAsNoTracking().Count();
        }


    }
}
