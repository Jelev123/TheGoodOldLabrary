namespace TheGoodOldLibrary.Services.Data.Book
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;

    public interface IBookService
    {
        Task CreateAsync(CreateBooksViewModel model);

        Task UpdateAsync(UpdateViewModel model, int id);

        IEnumerable<BookInListViewModel> GetAll<T>(int page, int itemsPerPage = 5);

        List<BookViewModel> GetById(int id);

        List<UpdateViewModel> ById<T>(int id);

        int GetCount();

    }
}
