namespace TheGoodOldLibrary.Services.Data.Book
{
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Models.ViewModel.Book;

    public interface IBookService
    {
        Task CreateAsync(CreateBooksViewModel model);

        Task UpdateAsync(BookViewModel model, int id);

        T GetById<T>(int id);
    }
}
