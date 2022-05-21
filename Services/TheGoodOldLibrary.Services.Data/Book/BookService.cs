namespace TheGoodOldLibrary.Services.Data.Book
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;
    using TheGoodOldLibrary.Services.Mapping;

    public class BookService : IBookService
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
                UriginalUrl = model.Image,
            };
            await this.bookRepository.AddAsync(book);
            await this.bookRepository.SaveChangesAsync();

        }

        public IEnumerable<BookInListViewModel> GetAll<T>(int page, int itemsPerPage = 10)
        {
            var book = this.bookRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(x => new BookInListViewModel
                {
                    Id = x.Id,
                    GenreId = x.Genre.Id,
                    GenreName = x.Genre.Name,
                    Name = x.Name,
                    Images = x.UriginalUrl,
                }).ToList();

            return book;
        }

        public int GetCount()
        {
            return this.bookRepository.All().Count();
        }
    }
}
