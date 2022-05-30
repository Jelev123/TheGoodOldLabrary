namespace TheGoodOldLibrary.Services.Data.PeriodicalTaking
{
    using System;
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
            var periodical = new PeriodicalTaking
            {
                Id = Guid.NewGuid().ToString(),
                PeriodicalId = takingServiceModel.PeriodicalId,
                UserId = takingServiceModel.UserId,
                Periodical = takingServiceModel.Periodical,
                User = takingServiceModel.User,
            };

            var periodicals = this.periodicalRepository.AllAsNoTracking().FirstOrDefault(s => s.Id == takingServiceModel.PeriodicalId);

            periodicals.PeriodicalCount -= 1;
            periodicals.OrderedTimes += 1;

            this.periodicalRepository.Update(periodicals);

            await this.periodicalTakingRepository.AddAsync(periodical);
            await this.periodicalTakingRepository.SaveChangesAsync();
        }
    }
}
