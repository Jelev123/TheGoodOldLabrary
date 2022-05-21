namespace TheGoodOldLibrary.Services.Data.Periodical
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Models.ViewModel.Periodical;

    public interface IPeriodicalService
    {
        Task CreateAsync(CreatePeridiocalViewModel model);

        IEnumerable<PeriodicalInListViewModel> GetAll<T>(int page, int itemsPerPage = 5);

        int GetCount();

    }
}
