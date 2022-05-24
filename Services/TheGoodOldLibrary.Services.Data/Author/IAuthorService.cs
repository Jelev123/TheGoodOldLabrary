namespace TheGoodOldLibrary.Services.Data.Author
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IAuthorService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

    }
}
