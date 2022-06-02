namespace TheGoodOldLibrary.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;
    using TheGoodOldLibrary.Data.Models.ViewModel.Home;
    using TheGoodOldLibrary.Data.Models.ViewModel.Periodical;
    using TheGoodOldLibrary.Web.ViewModels;

    public class HomeController : BaseController
    {
        private readonly IDeletableEntityRepository<Data.Models.Book> bookRepository;
        private readonly IDeletableEntityRepository<Data.Models.Periodical> periodicalRepository;
        private readonly IRepository<Data.Models.ApplicationUser> userlRepository;
        private readonly IMapper mapper;

        public HomeController(
                              IDeletableEntityRepository<Data.Models.Book> bookRepository,
                              IDeletableEntityRepository<Data.Models.Periodical> periodicalRepository,
                              IRepository<Data.Models.ApplicationUser> userlRepository,
                              IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.periodicalRepository = periodicalRepository;
            this.userlRepository = userlRepository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {

            var bookViewModel = this.bookRepository.All()
            .ProjectTo<BookInListViewModel>(this.mapper.ConfigurationProvider)
            .ToList();

            var periodicalViewModel = this.periodicalRepository.All()
            .ProjectTo<PeriodicalInListViewModel>(this.mapper.ConfigurationProvider)
            .ToList();

            var usersCount = this.userlRepository.All().Count();
            var booksCount = this.bookRepository.All().Count();
            var periodicalsCount = this.periodicalRepository.All().Count();

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
