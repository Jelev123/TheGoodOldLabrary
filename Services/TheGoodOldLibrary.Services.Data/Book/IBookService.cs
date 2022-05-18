namespace TheGoodOldLibrary.Services.Data.Book
{
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Web.ViewModels.Books;

    public interface IBookService
    {
        Task CreateAsync(CreateBooksViewModel model, string imagePath);
    }
}
