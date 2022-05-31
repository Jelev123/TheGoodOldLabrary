namespace TheGoodOldLibrary.Web.Controllers.Book
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;
    using TheGoodOldLibrary.Services.Data.Author;
    using TheGoodOldLibrary.Services.Data.Book;
    using TheGoodOldLibrary.Services.Data.BookTaking;
    using TheGoodOldLibrary.Services.Data.Genre;

    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IGenreService genreService;
        private readonly IAuthorService authorService;
        private readonly IBookTakingService takingService;


        public BooksController(IBookService bookService, IGenreService genreService, IAuthorService authorService, IBookTakingService takingService)
        {
            this.bookService = bookService;
            this.genreService = genreService;
            this.authorService = authorService;
            this.takingService = takingService;
        }

        public IActionResult Create()
        {
            return this.View(new CreateBooksViewModel
            {
                Authors = this.authorService.GetAll(),
                GenreItems = this.genreService.GetAllAsKeyValuePairs(),
            });
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

            return this.View(new BookListViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                BooksCount = this.bookService.GetCount(),
                Books = this.bookService.GetAll<BookInListViewModel>(id, 100),
            });
        }

        public IActionResult GetById(int id)
        {
            return this.View(this.bookService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> BookTaking(TakingServiceModel takingServiceModel)
        {
            takingServiceModel.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.takingService.Create(takingServiceModel);

            return this.Redirect("All");
        }

        public IActionResult Update(int id)
        {
            var inputModel = this.bookService.GetById(id);
            inputModel.GenreItems = this.genreService.GetAllAsKeyValuePairs();
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, BookViewModel input)
        {
            await this.bookService.UpdateAsync(input, id);

            return this.RedirectToAction(nameof(this.GetById), new { id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.bookService.DeleteAsync(id);

            return this.RedirectToAction("All");
        }
    }
}
