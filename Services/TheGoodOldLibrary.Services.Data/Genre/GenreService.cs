namespace TheGoodOldLibrary.Services.Data.Genre
{
    using System.Collections.Generic;
    using System.Linq;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;

    public class GenreService : IGenreService
    {
        private readonly IDeletableEntityRepository<Genre> genreRepository;

        public GenreService(IDeletableEntityRepository<Genre> genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.genreRepository.AllAsNoTracking()
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
