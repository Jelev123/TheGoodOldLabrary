namespace TheGoodOldLibrary.Web.Controllers.Book
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using TheGoodOldLibrary.Services.Data.Book;
    using TheGoodOldLibrary.Services.Data.Genre;
    using TheGoodOldLibrary.Web.ViewModels.Books;

    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IGenreService genreService;
        private readonly IWebHostEnvironment environment;

        public BooksController(IBookService bookService,  IWebHostEnvironment environment, IGenreService genreService)
        {
            this.bookService = bookService;
            this.environment = environment;
            this.genreService = genreService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateBooksViewModel();
            viewModel.GenreItems = this.genreService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBooksViewModel model)
        {
            await this.bookService.CreateAsync(model, $"{this.environment.WebRootPath}/images");

            return this.RedirectToAction("All");
        }
    }
}
