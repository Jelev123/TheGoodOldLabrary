namespace TheGoodOldLibrary.Services.Data.Type
{
    using System.Collections.Generic;
    using System.Linq;

    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;

    public class TypeService : ITypeService
    {
        private readonly IDeletableEntityRepository<Types> typeRepository;

        public TypeService(IDeletableEntityRepository<Types> typeRepository)
        {
            this.typeRepository = typeRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.typeRepository.AllAsNoTracking()
                  .Select(x => new
                  {
                      x.Id,
                      x.Name,
                  }).OrderBy(s => s.Name)
                  .ToList()
                  .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
