namespace TheGoodOldLibrary.Services.Data.Periodical
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.Periodical;

    public class PeriodicalService : IPeriodicalService
    {
        private readonly IDeletableEntityRepository<Periodical> periodicalRepository;
        private readonly IDeletableEntityRepository<PeriodicalTaking> periodicalTakingRepository;
        private readonly IMapper mapper;

        public PeriodicalService(IDeletableEntityRepository<Periodical> periodicalRepository, IMapper mapper, IDeletableEntityRepository<PeriodicalTaking> periodicalTakingRepository)
        {
            this.periodicalRepository = periodicalRepository;
            this.mapper = mapper;
            this.periodicalTakingRepository = periodicalTakingRepository;
        }

        public async Task CreateAsync(CreatePeridiocalViewModel model)
        {
            var periodical = new Periodical
            {
                Name = model.Name,
                TypeId = model.TypeId,
                OriginalUrl = model.OriginalUrl,
                PeriodicalCount = model.PeriodicalCount,
            };

            await this.periodicalRepository.AddAsync(periodical);
            await this.periodicalRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(PeriodicalInListViewModel model, int id)
        {
            var periodical = this.periodicalRepository.AllAsNoTracking().FirstOrDefault(s => s.Id == id);
            periodical.Name = model.Name;
            periodical.OriginalUrl = model.OriginalUrl;
            periodical.PeriodicalCount = model.PeriodicalCount;
            periodical.TypeId = model.TypeId;

            this.periodicalRepository.Update(periodical);
            await this.periodicalRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var periodical = this.periodicalRepository.AllAsNoTracking().FirstOrDefault(s => s.Id == id);
            this.periodicalRepository.Delete(periodical);
            await this.periodicalRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 5)
        {
            return this.periodicalRepository.AllAsNoTracking()
               .OrderBy(x => x.Name)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public T GetById<T>(int id)
        {
            var periodical = this.periodicalRepository.AllAsNoTracking()
                .Where(s => s.Id == id)
               .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

            return periodical;
        }

        public int GetCount()
        {
            return this.periodicalRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetMostOrdered<T>(int page, int itemsPerPage = 6)
        {
            return this.periodicalRepository.AllAsNoTracking()
                .OrderByDescending(s => s.OrderedTimes)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public IEnumerable<T> GetLessOrdered<T>(int page, int itemsPerPage = 6)
        {
            return this.periodicalRepository.AllAsNoTracking()
               .OrderBy(s => s.OrderedTimes)
               .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
               .ProjectTo<T>(this.mapper.ConfigurationProvider)
               .ToList();
        }

        public IEnumerable<KeyValuePair<int, int>> GetMostOrdered2(int page, int itemsPerPage)
        {
            var top = new Dictionary<int, int>();

            var orders = this.periodicalTakingRepository.AllAsNoTracking()
                .ToList();

            foreach (var order in orders)
            {
                if (!top.ContainsKey(order.PeriodicalId))
                {
                    top.Add(order.PeriodicalId, 0);
                }

                top[order.PeriodicalId] += 1;
            }

            return top.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).OrderByDescending(s => s.Value);
        }

        public IEnumerable<KeyValuePair<int, int>> GetLessOrdered2(int page, int itemsPerPage)
        {
            var top = new Dictionary<int, int>();

            var orders = this.periodicalTakingRepository.AllAsNoTracking()
                .ToList();

            foreach (var order in orders)
            {
                if (!top.ContainsKey(order.PeriodicalId))
                {
                    top.Add(order.PeriodicalId, 0);
                }

                top[order.PeriodicalId] += 1;
            }

            return top.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).OrderBy(s => s.Value);

        }
    }
}
