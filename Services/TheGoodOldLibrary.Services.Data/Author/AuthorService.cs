namespace TheGoodOldLibrary.Services.Data.Author
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.Author;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;

    public class AuthorService : IAuthorService
    {
        private readonly IDeletableEntityRepository<Author> authorRepository;

        public AuthorService(IDeletableEntityRepository<Author> authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task CreateAsync(CreateAuthorViewModel model)
        {
            var author = new Author()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            await this.authorRepository.AddAsync(author);
            await this.authorRepository.SaveChangesAsync();
        }

        public IEnumerable<AllAuthorsViewModel> GetAll()
        {
            return this.authorRepository.AllAsNoTracking()
                .Select(s => new AllAuthorsViewModel
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                }).ToList();
        }
    }
}
