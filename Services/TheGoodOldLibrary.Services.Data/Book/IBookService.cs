namespace TheGoodOldLibrary.Services.Data.Book
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;

    public interface IBookService
    {
        Task CreateAsync(CreateBooksViewModel model);

        IEnumerable<BookInListViewModel> GetAll<T>(int page, int itemsPerPage = 5);

        int GetCount();

    }
}
