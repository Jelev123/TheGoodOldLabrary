namespace TheGoodOldLibrary.Services.Data.PeriodicalTaking
{
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;

    public interface IPeriodicalTakingService
    {
        Task Create(TakingServiceModel takingServiceModel);

    }
}
