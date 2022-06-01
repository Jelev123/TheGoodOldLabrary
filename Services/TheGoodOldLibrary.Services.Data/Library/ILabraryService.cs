namespace TheGoodOldLibrary.Services.Data.Library
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILabraryService
    {
        Task DeleteAsync(int id);

        IEnumerable<T> GetMostOrdered<T>();

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6);

        int GetCount();
    }
}
