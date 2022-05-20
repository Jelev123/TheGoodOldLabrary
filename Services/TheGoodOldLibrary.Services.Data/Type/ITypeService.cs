namespace TheGoodOldLibrary.Services.Data.Type
{
    using System.Collections.Generic;

    public interface ITypeService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
