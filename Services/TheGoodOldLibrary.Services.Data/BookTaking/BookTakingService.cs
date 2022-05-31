namespace TheGoodOldLibrary.Services.Data.BookTaking
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;

    public class BookTakingService : IBookTakingService
    {
        private readonly IDeletableEntityRepository<BookTaking> bookTakingRepository;
        private readonly IDeletableEntityRepository<Book> bookRepository;

        public BookTakingService(IDeletableEntityRepository<BookTaking> bookTakingRepository, IDeletableEntityRepository<Book> bookRepository)
        {
            this.bookTakingRepository = bookTakingRepository;
            this.bookRepository = bookRepository;
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
            book.OrderedTimes += 1;

            this.bookRepository.Update(book);

            await this.bookTakingRepository.AddAsync(taking);
            await this.bookTakingRepository.SaveChangesAsync();
        }
    }
}
