namespace TheGoodOldLibrary.Services.Data.Book
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;

    public class BookService : IBookService
    {
        private readonly IDeletableEntityRepository<Book> bookRepository;
        private readonly IDeletableEntityRepository<Author> authorRepository;

        public BookService(IDeletableEntityRepository<Book> bookRepository, IDeletableEntityRepository<Author> authorRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }

        public async Task CreateAsync(CreateBooksViewModel model)
        {

            var book = new Book
            {
                Name = model.Name,
                GenreId = model.GenreId,
                OriginalUrl = model.Image,
                AuthorId = model.AuthorId,
                BookCount = model.BookCount,
            };

            await this.bookRepository.AddAsync(book);
            await this.bookRepository.SaveChangesAsync();
        }

        public IEnumerable<BookInListViewModel> GetAll<T>(int page, int itemsPerPage = 10)
        {
            return this.bookRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(x => new BookInListViewModel
                {
                    Id = x.Id,
                    GenreId = x.Genre.Id,
                    GenreName = x.Genre.Name,
                    AuthorId = x.AuthorId,
                    Name = x.Name,
                    Images = x.OriginalUrl,
                    BooksCount = x.BookCount,
                }).ToList();
        }

        public List<BookViewModel> GetById(int id)
        {
            var book = this.bookRepository.AllAsNoTracking()
                   .Where(s => s.Id == id)
                  .Select(s => new BookViewModel
                  {
                      AuthorId = s.AuthorId,
                      AuthorFirstName = s.Author.FirstName,
                      AuthorLastName = s.Author.LastName,
                      Name = s.Name,
                      GenreId = s.GenreId,
                      GenreName = s.Genre.Name,
                      Id = s.Id,
                      ImageUrl = s.OriginalUrl,
                      BookCount = s.BookCount,
                  }).ToList();

            return book;
        }

        public int GetCount()
        {
            return this.bookRepository.AllAsNoTracking().Count();
        }

        public async Task UpdateAsync(UpdateViewModel model)
        {
            var book = this.bookRepository.AllAsNoTracking().FirstOrDefault(s => s.Id == model.BookId);
            book.Name = model.Name;
            book.BookCount = model.BookCount;
            book.GenreId = model.GenreId;
            book.AuthorId = model.AuthorId;
            book.OriginalUrl = model.Image;

            await this.bookRepository.SaveChangesAsync();
        }
    }
}
