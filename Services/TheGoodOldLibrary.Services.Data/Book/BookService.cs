namespace TheGoodOldLibrary.Services.Data.Book
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;
    using TheGoodOldLibrary.Services.Data.Library;

    public class BookService : IBookService, ILabraryService
    {
        private readonly IDeletableEntityRepository<Book> bookRepository;

        public BookService(IDeletableEntityRepository<Book> bookRepository)
        {
            this.bookRepository = bookRepository;
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

        public async Task UpdateAsync(BookViewModel model, int id)
        {
            var book = this.bookRepository.AllAsNoTracking().FirstOrDefault(s => s.Id == id);
            book.Name = model.Name;
            book.BookCount = model.BookCount;
            book.GenreId = model.GenreId;
            book.AuthorId = model.AuthorId;
            book.OriginalUrl = model.ImageUrl;

            this.bookRepository.Update(book);
            await this.bookRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = this.bookRepository.AllAsNoTracking().FirstOrDefault(s => s.Id == id);
            this.bookRepository.Delete(book);
            await this.bookRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 10)
        {
            return (IEnumerable<T>)this.bookRepository.AllAsNoTracking()
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

        public BookViewModel GetById<T>(int id)
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
                  }).FirstOrDefault();

            return book;
        }

        public int GetCount()
        {
            return this.bookRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetMostOrdered<T>()
        {
            var ordered = (IEnumerable<T>)this.bookRepository.AllAsNoTracking()
                 .Where(s => s.OrderedTimes > 5)
                 .Select(s => new BookInListViewModel
                 {
                     Id = s.Id,
                     BooksCount = s.BookCount,
                     Name = s.Name,
                     GenreName = s.Genre.Name,
                     GenreId = s.GenreId,
                     AuthorId = s.AuthorId,
                     OrderedTimes = s.OrderedTimes,
                     Images = s.OriginalUrl,
                 })
                 .ToList();

            return ordered;
        }
    }
}
