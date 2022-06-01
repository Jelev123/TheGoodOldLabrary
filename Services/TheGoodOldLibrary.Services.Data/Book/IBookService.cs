namespace TheGoodOldLibrary.Services.Data.Book
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;

    public interface IBookService
    {
        Task CreateAsync(CreateBooksViewModel model);

        Task UpdateAsync(BookViewModel model, int id);

        Task DeleteAsync(int id);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 5);

        IEnumerable<T> GetMostOrdered<T>();

        BookViewModel GetById<T>(int id);

        int GetCount();
    }
}
