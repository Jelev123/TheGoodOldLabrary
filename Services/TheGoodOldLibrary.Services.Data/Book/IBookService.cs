namespace TheGoodOldLibrary.Services.Data.Book
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Models.ViewModel.Book;

    public interface IBookService
    {
        Task CreateAsync(CreateBooksViewModel model);

        Task UpdateAsync(BookViewModel model, int id);

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
