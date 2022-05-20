namespace TheGoodOldLibrary.Services.Data.Genre
{
    using System.Collections.Generic;

    public interface IGenreService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

    }
}
