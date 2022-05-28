namespace TheGoodOldLibrary.Services.Data.BookTaking
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TheGoodOldLibrary.Data;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;

    public class BookTakingService : IBookTakingService
    {
        private readonly ApplicationDbContext data;
        private readonly IRepository<BookTaking> bookTakingRepository;

        public BookTakingService(ApplicationDbContext data, IRepository<BookTaking> bookRepository)
        {
            this.data = data;
            this.bookTakingRepository = bookRepository;
        }

        public async Task Create(TakingServiceModel takingServiceModel)
        {
            BookTaking taking = new()
            {
                Id = Guid.NewGuid().ToString(),
                BookId = takingServiceModel.BookId,
                BookStatusId = takingServiceModel.BookStatusId,
                PeriodicalId = takingServiceModel.PeriodicalId,
                UserId = takingServiceModel.UserId,
            };

            await this.bookTakingRepository.AddAsync(taking);
            await this.bookTakingRepository.SaveChangesAsync();
        }
    }
}
