namespace TheGoodOldLibrary.Services.Data.Author
{
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.Author;

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
    }
}
