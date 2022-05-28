namespace TheGoodOldLibrary.Services.Data.BookTaking
{
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;

    public interface IBookTakingService
    {
        Task Create(TakingServiceModel takingServiceModel);

    }
}
