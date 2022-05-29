namespace TheGoodOldLibrary.Services.Data.BookTaking
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;

    public class BookTakingService : IBookTakingService
    {
        private readonly IDeletableEntityRepository<BookTaking> bookTakingRepository;
        private readonly IDeletableEntityRepository<Book> bookRepository;
        private readonly ApplicationDbContext data;

        public BookTakingService(IDeletableEntityRepository<BookTaking> bookTakingRepository, ApplicationDbContext data, IDeletableEntityRepository<Book> bookRepository)
        {
            this.bookTakingRepository = bookTakingRepository;
            this.data = data;
            this.bookRepository = bookRepository;
        }

        public async Task Create(TakingServiceModel takingServiceModel)
        {
            var taking = new BookTaking()
            {
                Id = Guid.NewGuid().ToString(),
                BookId = takingServiceModel.BookId,
                UserId = takingServiceModel.UserId,
            };

            var book = this.bookRepository.AllAsNoTracking()
                .FirstOrDefault(s => s.Id == takingServiceModel.BookId);
            book.BookCount -= 1;
            book.OrderedTimes += 1;

            this.bookRepository.Update(book);

            await this.bookTakingRepository.AddAsync(taking);
            await this.bookTakingRepository.SaveChangesAsync();
        }
    }
}
