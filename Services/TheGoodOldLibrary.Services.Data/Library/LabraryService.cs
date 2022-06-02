namespace TheGoodOldLibrary.Services.Data.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LabraryService : ILabraryService
    {
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetMostOrdered<T>()
        {
            throw new NotImplementedException();
        }
    }
}
