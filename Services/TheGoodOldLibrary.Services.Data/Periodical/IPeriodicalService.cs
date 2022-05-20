namespace TheGoodOldLibrary.Services.Data.Periodical
{
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Web.ViewModels.Peridiocal;

    public interface IPeriodicalService
    {
        Task CreateAsync(CreatePeridiocalViewModel model, string imagePath);

    }
}
