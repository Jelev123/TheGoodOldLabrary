namespace TheGoodOldLibrary.Services.Data.Book
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;

    public interface IBookService
    {
        Task CreateAsync(CreateBooksViewModel model);

        Task UpdateAsync(UpdateViewModel model);

        IEnumerable<BookInListViewModel> GetAll<T>(int page, int itemsPerPage = 5);

        List<BookViewModel> GetById(int id);

        int GetCount();

    }
}
