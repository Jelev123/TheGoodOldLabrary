namespace TheGoodOldLibrary.Services.Data.BookTaking
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TheGoodOldLibrary.Data;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;

    public class BookTakingService : IBookTakingService
    {
        private readonly ApplicationDbContext data;
        private readonly IRepository<BookTaking> bookRepository;

        public BookTakingService(ApplicationDbContext data, IRepository<BookTaking> bookRepository)
        {
            this.data = data;
            this.bookRepository = bookRepository;
        }
        public async Task<bool> Create(TakingServiceModel takingServiceModel)
        {
            BookTaking taking = new()
            {
                Id = Guid.NewGuid().ToString(),
                BookId = takingServiceModel.BookId,
                BookStatusId = takingServiceModel.BookStatusId,
                PeriodicalId = takingServiceModel.PeriodicalId,
                UserId = takingServiceModel.UserId,
                User = takingServiceModel.User,
                BookStatus = takingServiceModel.BookStatus,
                Periodical = takingServiceModel.Periodical,
            };

            taking.BookStatus = await this.data.BookStatuses.FirstOrDefaultAsync(bookstatus => bookstatus.Name == "Available");

            await this.bookRepository.AddAsync(taking);
            int result = await this.bookRepository.SaveChangesAsync();

            return result > 0;
        }
    }
}
