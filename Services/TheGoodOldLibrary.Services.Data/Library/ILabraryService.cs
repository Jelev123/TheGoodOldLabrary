namespace TheGoodOldLibrary.Services.Data.Library
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILabraryService
    {
        Task DeleteBooksAsync(int id);

        IEnumerable<T> GetMostOrderedBooks<T>();

        IEnumerable<T> GetLessOrderedBooks<T>();

        IEnumerable<T> GetAllBooks<T>(int page, int itemsPerPage = 6);
        T GetBooksById<T>(int id);

        int GetBooksCount();
    }
}
