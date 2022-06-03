namespace TheGoodOldLibrary.Services.Data.PeriodicalTaking
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;
    using TheGoodOldLibrary.Data.Models.ViewModel.Periodical;

    public interface IPeriodicalTakingService
    {
        Task Create(TakingServiceModel takingServiceModel);

        List<AllTakings> GetOrders<T>(string id, bool isTaken);

        void Return<T>(string orderedId);

    }
}
