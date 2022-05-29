namespace TheGoodOldLibrary.Services.Data.PeriodicalTaking
{
    using System;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;

    public class PeriodicalTakingService : IPeriodicalTakingService
    {
        private readonly IDeletableEntityRepository<PeriodicalTaking> periodicalRepository;

        public PeriodicalTakingService(IDeletableEntityRepository<PeriodicalTaking> periodicalRepository)
        {
            this.periodicalRepository = periodicalRepository;
        }

        public async Task Create(TakingServiceModel takingServiceModel)
        {
            var periodical = new PeriodicalTaking
            {
                Id = Guid.NewGuid().ToString(),
                PeriodicalId = takingServiceModel.PeriodicalId,
                UserId = takingServiceModel.UserId,
            };

            await this.periodicalRepository.AddAsync(periodical);
            await this.periodicalRepository.SaveChangesAsync();
        }
    }
}
