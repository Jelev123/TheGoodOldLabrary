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
        private readonly BookService bookService;
        private readonly Author author;
        private readonly IWebHostEnvironment environment;

        public BooksController(BookService bookService, Author author, IWebHostEnvironment environment)
        {
            this.bookService = bookService;
            this.author = author;
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
            await this.bookService.CreateAsync(model, this.author.Id, $"{this.environment.WebRootPath}/images");

           
        }
    }
}
