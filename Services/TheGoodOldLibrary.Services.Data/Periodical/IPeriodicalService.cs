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

        T GetById<T>(int id);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6);

        IEnumerable<T> GetMostOrdered<T>(int page, int itemsPerPage = 6);

        IEnumerable<T> GetLessOrdered<T>(int page, int itemsPerPage = 6);

        IEnumerable<KeyValuePair<int, int>> GetMostOrdered2(int page, int itemsPerPage = 6);

        IEnumerable<KeyValuePair<int, int>> GetLessOrdered2(int page, int itemsPerPage = 6);

        int GetCount();
    }
}
