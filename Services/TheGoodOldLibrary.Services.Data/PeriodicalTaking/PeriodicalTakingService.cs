namespace TheGoodOldLibrary.Services.Data.PeriodicalTaking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;

    public class PeriodicalTakingService : IPeriodicalTakingService
    {
        private readonly IDeletableEntityRepository<PeriodicalTaking> periodicalTakingRepository;
        private readonly IDeletableEntityRepository<Periodical> periodicalRepository;

        public PeriodicalTakingService(IDeletableEntityRepository<PeriodicalTaking> periodicalTakingRepository, IDeletableEntityRepository<Periodical> periodicalRepository)
        {
            this.periodicalTakingRepository = periodicalTakingRepository;
            this.periodicalRepository = periodicalRepository;
        }

        public async Task Create(TakingServiceModel takingServiceModel)
        {
            var periodicals = this.periodicalRepository.AllAsNoTracking().FirstOrDefault(s => s.Id == takingServiceModel.PeriodicalId);

            if (periodicals.PeriodicalCount == 0)
            {
                return;
            }

            var periodical = new PeriodicalTaking
            {
                Id = Guid.NewGuid().ToString(),
                PeriodicalId = takingServiceModel.PeriodicalId,
                UserId = takingServiceModel.UserId,
                Periodical = takingServiceModel.Periodical,
                User = takingServiceModel.User,
            };

            periodical.IsTaken = true;
            periodicals.PeriodicalCount -= 1;
            periodicals.OrderedTimes += 1;

            this.periodicalRepository.Update(periodicals);

            await this.periodicalTakingRepository.AddAsync(periodical);
            await this.periodicalTakingRepository.SaveChangesAsync();
        }

        public List<AllTakings> GetOrders<T>(string id, bool isTaken)
        {
            return this.periodicalTakingRepository.AllAsNoTracking()
                .Where(s => s.UserId == id && s.IsTaken == isTaken)
               .Select(s => new AllTakings
               {
                   PeriodicalName = s.Periodical.Name,
                   UserName = s.User.UserName,
                   IsTaken = s.IsTaken,
                   CreatedOn = s.CreatedOn,
                   ModifiedOn = s.ModifiedOn,
                   Id = s.Id,
               })
                .ToList();
        }

        public void Return<T>(string orderedId)
        {
            var order = this.periodicalTakingRepository.AllAsNoTracking()
                .Where(s => s.Id == orderedId).FirstOrDefault();

            var periodical = this.periodicalRepository.AllAsNoTracking()
                 .Where(s => s.Id == order.PeriodicalId).FirstOrDefault();

            periodical.PeriodicalCount += 1;
            order.IsTaken = false;

            this.periodicalRepository.Update(periodical);
            this.periodicalTakingRepository.Update(order);

            this.periodicalRepository.SaveChangesAsync();
            this.periodicalTakingRepository.SaveChangesAsync();
        }
    }
}
