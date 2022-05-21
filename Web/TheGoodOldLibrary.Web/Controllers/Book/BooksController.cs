namespace TheGoodOldLibrary.Web.Controllers.Book
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;
    using TheGoodOldLibrary.Services.Data.Book;
    using TheGoodOldLibrary.Services.Data.Genre;

    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IGenreService genreService;

        public BooksController(IBookService bookService, IGenreService genreService)
        {
            this.bookService = bookService;
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
            await this.bookService.CreateAsync(model);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 9;

            var viewModel = new BookListViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                BooksCount = this.bookService.GetCount(),
                Books = this.bookService.GetAll<BookInListViewModel>(id, 1),
            };
            return this.View(viewModel);
        }
    }
}
