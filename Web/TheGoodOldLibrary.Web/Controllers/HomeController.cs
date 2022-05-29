namespace TheGoodOldLibrary.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using TheGoodOldLibrary.Data;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;
    using TheGoodOldLibrary.Data.Models.ViewModel.Home;
    using TheGoodOldLibrary.Data.Models.ViewModel.Periodical;
    using TheGoodOldLibrary.Services.Data.Book;
    using TheGoodOldLibrary.Web.ViewModels;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext data;
        private readonly IBookService bookService;
        private readonly IDeletableEntityRepository<Data.Models.Book> bookRepository;
        private readonly IDeletableEntityRepository<Data.Models.Periodical> periodicalRepository;


        public HomeController(IBookService bookService, IDeletableEntityRepository<Data.Models.Book> bookRepository,
            IDeletableEntityRepository<Data.Models.Periodical> periodicalRepository,
            ApplicationDbContext data)
        {
            this.bookService = bookService;
            this.bookRepository = bookRepository;
            this.periodicalRepository = periodicalRepository;
            this.data = data;
        }

        public IActionResult Index()
        {
            var bookViewModel = this.bookRepository.All().Select(s => new BookInListViewModel()
            {
                Id = s.Id,
                Name = s.Name,
                GenreName = s.Genre.Name,
                Images = s.OriginalUrl,
            }).ToList();


            var periodicalViewModel = this.periodicalRepository.All().Select(s => new PeriodicalInListViewModel
            {
                Name = s.Name,
                TypeName = s.Type.Name,
                Image = s.ImageUrl,
                Id = s.Id,
            }).ToList();

            var usersCount = this.data.Users.Count();
            var booksCount = this.data.Books.Count();
            var periodicalsCount = this.data.Periodicals.Count();


            return this.View(new HomeViewModel()
            {
                Books = bookViewModel,
                Periodicals = periodicalViewModel,
                UsersCount = usersCount,
                BooksCount = booksCount,
                PerodicalsCount = periodicalsCount,
            });
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
