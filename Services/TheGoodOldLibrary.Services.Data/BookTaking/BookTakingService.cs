namespace TheGoodOldLibrary.Services.Data.BookTaking
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;

    public class BookTakingService : IBookTakingService
    {
        private readonly IDeletableEntityRepository<BookTaking> bookTakingRepository;
        private readonly IDeletableEntityRepository<Book> bookRepository;
        private readonly IMapper mapper;

        public BookTakingService(IDeletableEntityRepository<BookTaking> bookTakingRepository, IDeletableEntityRepository<Book> bookRepository, IMapper mapper)
        {
            this.bookTakingRepository = bookTakingRepository;
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public async Task Create(TakingServiceModel takingServiceModel)
        {
            var book = this.bookRepository.AllAsNoTracking()
               .FirstOrDefault(s => s.Id == takingServiceModel.BookId);

            if (book.BookCount == 0)
            {
                return;
            }

            var taking = new BookTaking()
            {
                Id = Guid.NewGuid().ToString(),
                BookId = takingServiceModel.BookId,
                UserId = takingServiceModel.UserId,
            };

            book.BookCount -= 1;
            taking.IsTaken = true;
            book.OrderedTimes += 1;

            this.bookRepository.Update(book);

            await this.bookTakingRepository.AddAsync(taking);
            await this.bookTakingRepository.SaveChangesAsync();
        }

        public List<AllTakings> GetOrders<T>(string orderedId, bool isTaken)
        {
            return this.bookTakingRepository.AllAsNoTracking()
                .Where(s => s.UserId == orderedId && s.IsTaken == isTaken)
               .Select(s => new AllTakings
               {
                   BookName = s.Book.Name,
                   UserName = s.User.UserName,
                   IsTaken = s.IsTaken,
                   CreatedOn = s.CreatedOn,
                   ModifiedOn = s.ModifiedOn,
                   Id = s.Id,
               })
                .ToList();
        }

        public void Return<T>(string orderedId)
        {
            var order = this.bookTakingRepository.AllAsNoTracking()
                 .Where(s => s.Id == orderedId).FirstOrDefault();

            var book = this.bookRepository.AllAsNoTracking()
                 .Where(s => s.Id == order.BookId).FirstOrDefault();

            book.BookCount += 1;
            order.IsTaken = false;

            this.bookRepository.Update(book);
            this.bookTakingRepository.Update(order);

            this.bookRepository.SaveChangesAsync();
            this.bookTakingRepository.SaveChangesAsync();

           
        }
    }
}
