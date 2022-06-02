namespace TheGoodOldLibrary.Services.Data.BookTaking
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;

    public interface IBookTakingService
    {
        Task Create(TakingServiceModel takingServiceModel);

        List<AllTakingsBook> GetOrders<T>(string id, bool isTaken);

        void Return<T>(string orderedId);
    }
}
