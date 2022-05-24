namespace TheGoodOldLibrary.Services.Data.Author
{
    using System.Collections.Generic;
    using System.Linq;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;

    public class AuthorService : IAuthorService
    {
        private readonly IDeletableEntityRepository<Author> authorRepository;

        public AuthorService(IDeletableEntityRepository<Author> authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.authorRepository.AllAsNoTracking()
                 .Select(x => new
                 {
                     x.Id,
                     x.Name,
                 })
                 .OrderBy(x => x.Name)
                 .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
