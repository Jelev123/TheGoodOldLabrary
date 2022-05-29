namespace TheGoodOldLibrary.Services.Data.BookTaking
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;

    public class BookTakingService : IBookTakingService
    {
        private readonly IDeletableEntityRepository<BookTaking> bookTakingRepository;
        private readonly ApplicationDbContext data;

        public BookTakingService(IDeletableEntityRepository<BookTaking> bookTakingRepository, ApplicationDbContext data)
        {
            this.bookTakingRepository = bookTakingRepository;
            this.data = data;
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

            taking.BookStatus = await this.data.BookStatuses
                .SingleOrDefaultAsync(orderStatus => orderStatus.Id == 1);

            await this.bookTakingRepository.AddAsync(taking);
            await this.bookTakingRepository.SaveChangesAsync();
        }
    }
}
