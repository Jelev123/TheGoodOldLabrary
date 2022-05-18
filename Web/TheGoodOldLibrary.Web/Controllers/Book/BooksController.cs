namespace TheGoodOldLibrary.Web.Controllers.Book
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Services.Data.Book;
    using TheGoodOldLibrary.Web.ViewModels.Books;

    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IWebHostEnvironment environment;

        public BooksController(IBookService bookService,  IWebHostEnvironment environment)
        {
            this.bookService = bookService;
            this.environment = environment;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateBooksViewModel();
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
