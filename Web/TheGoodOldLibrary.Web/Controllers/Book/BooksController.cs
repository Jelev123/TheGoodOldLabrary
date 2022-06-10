namespace TheGoodOldLibrary.Web.Controllers.Book
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;
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

        public IActionResult Update(int id)
        {
            var inputModel = this.bookService.GetById<BookViewModel>(id);
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

        public async Task<IActionResult> All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 6;

            return this.View(new BookListViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                BooksCount = this.bookService.GetCount(),
                Books = this.bookService.GetAll<BookInListViewModel>(id, ItemsPerPage),
            });
        }

        public IActionResult GetById(int id)
        {
            return this.View(this.bookService.GetById<BookViewModel>(id));
        }

        public async Task<IActionResult> GetMostOrdered(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 6;

            return this.View(new BookListViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                BooksCount = this.bookService.GetCount(),
                Books = this.bookService.GetMostOrdered<BookInListViewModel>(id, ItemsPerPage),
            });
        }

        public async Task<IActionResult> GetLessOrdered(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 6;

            return this.View(new BookListViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                BooksCount = this.bookService.GetCount(),
                Books = this.bookService.GetLessOrdered<BookInListViewModel>(id, ItemsPerPage),
            });
        }

        public async Task<IActionResult> GetMostOrdered2(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 6;
            var or = this.bookService.GetMostOrdered2(id, ItemsPerPage);
            return this.View(new BookListViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                BooksCount = this.bookService.GetCount(),
                Books = this.bookService.GetAll<BookInListViewModel>(id, ItemsPerPage),
                Orders = this.bookService.GetMostOrdered2(id, ItemsPerPage),
            });
        }

        public async Task<IActionResult> GetLessOrdered2(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 6;

            return this.View(new BookListViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                BooksCount = this.bookService.GetCount(),
                Books = this.bookService.GetAll<BookInListViewModel>(id, ItemsPerPage),
                Orders = this.bookService.GetLessOrdered2(id, ItemsPerPage),
            });
        }
    }
}
