﻿namespace TheGoodOldLibrary.Services.Data.Book
{
    using System.Collections.Generic;
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
                AuthorId = model.AuthorId,
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
                    AuthorName = x.Author.Name,
                    Name = x.Name,
                    Images = x.UriginalUrl,
                }).ToList();
        }

        public T GetById<T>(int id)
        {
            return this.bookRepository.AllAsNoTracking()
                  .Where(s => s.Id == id)
                 .To<T>().FirstOrDefault();
        }

        public int GetCount()
        {
            return this.bookRepository.All().Count();
        }
    }
}
