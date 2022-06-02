namespace TheGoodOldLibrary.Services.Data.Library
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;

    public class LabraryService : ILabraryService
    {
        private readonly IDeletableEntityRepository<Book> bookRepository;
        private readonly IDeletableEntityRepository<Periodical> periodicalRepository;
        private readonly IMapper mapper;

        public LabraryService(IDeletableEntityRepository<Book> bookRepository, IMapper mapper, IDeletableEntityRepository<Periodical> periodicalRepository)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
            this.periodicalRepository = periodicalRepository;
        }

        public async Task DeleteBooksAsync(int id)
        {
            var book = this.bookRepository.AllAsNoTracking().FirstOrDefault(s => s.Id == id);
            this.bookRepository.Delete(book);
            await this.bookRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllBooks<T>(int page, int itemsPerPage = 6)
        {
            return this.bookRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public int GetBooksCount()
        {
            return this.bookRepository.AllAsNoTracking().Count();

        }

        public IEnumerable<T> GetMostOrderedBooks<T>()
        {
            return this.bookRepository.AllAsNoTracking()
                 .Where(s => s.OrderedTimes > 5)
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                 .ToList();
        }

        public IEnumerable<T> GetLessOrderedBooks<T>()
        {
            return this.bookRepository.AllAsNoTracking()
                .Where(s => s.OrderedTimes < 5)
               .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public T GetBooksById<T>(int id)
        {
            var book = this.bookRepository.AllAsNoTracking()
                  .Where(s => s.Id == id)
              .ProjectTo<T>(this.mapper.ConfigurationProvider)
                 .FirstOrDefault();

            return book;
        }
    }
}
