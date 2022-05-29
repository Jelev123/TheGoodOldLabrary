namespace TheGoodOldLibrary.Services.Data.BookTaking
{
    using System;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;

    public class BookTakingService : IBookTakingService
    {
        private readonly IDeletableEntityRepository<BookTaking> bookTakingRepository;

        public BookTakingService(IDeletableEntityRepository<BookTaking> bookTakingRepository)
        {
            this.bookTakingRepository = bookTakingRepository;
        }

        public async Task Create(TakingServiceModel takingServiceModel)
        {
            var taking = new BookTaking()
            {
                Id = Guid.NewGuid().ToString(),
                BookId = takingServiceModel.BookId,
                BookStatusId = takingServiceModel.BookStatusId,
                UserId = takingServiceModel.UserId,
            };

            await this.bookTakingRepository.AddAsync(taking);
            await this.bookTakingRepository.SaveChangesAsync();
        }
    }
}
