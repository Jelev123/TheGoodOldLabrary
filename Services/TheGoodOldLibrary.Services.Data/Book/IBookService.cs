namespace TheGoodOldLibrary.Services.Data.Book
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Web.ViewModels.Books;

    public interface IBookService
    {
        Task CreateAsync(CreateBooksViewModel model, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 100);

        int GetCount();

    }
}
