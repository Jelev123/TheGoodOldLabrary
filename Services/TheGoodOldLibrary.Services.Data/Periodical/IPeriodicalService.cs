namespace TheGoodOldLibrary.Services.Data.Periodical
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Models.ViewModel.Periodical;

    public interface IPeriodicalService
    {
        Task CreateAsync(CreatePeridiocalViewModel model);

        Task UpdateAsync(PeriodicalInListViewModel model, int id);

        Task DeleteAsync(int id);

        IEnumerable<PeriodicalInListViewModel> GetAll<T>(int page, int itemsPerPage = 5);

        PeriodicalInListViewModel GetById<T>(int id);

        int GetCount();

    }
}
