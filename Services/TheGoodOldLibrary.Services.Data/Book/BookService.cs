namespace TheGoodOldLibrary.Services.Data.Book
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
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
        private readonly IMapper mapper;

        public BookService(IDeletableEntityRepository<Book> bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
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
            book.OriginalUrl = model.OriginalUrl;

            this.bookRepository.Update(book);
            await this.bookRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = this.bookRepository.AllAsNoTracking().FirstOrDefault(s => s.Id == id);
            this.bookRepository.Delete(book);
            await this.bookRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6)
        {
            return this.bookRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public T GetById<T>(int id)
        {
            var book = this.bookRepository.AllAsNoTracking()
                   .Where(s => s.Id == id)
               .ProjectTo<T>(this.mapper.ConfigurationProvider)
                  .FirstOrDefault();

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
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                 .ToList();

            return ordered;
        }
    }
}
