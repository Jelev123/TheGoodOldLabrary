namespace TheGoodOldLibrary.Web.Controllers.Author
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Models.ViewModel.Author;
    using TheGoodOldLibrary.Services.Data.Author;

    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;

        public AuthorController( IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        public IActionResult CreateAuthor()
        {
            var viewModel = new CreateAuthorViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorViewModel model)
        {
            await this.authorService.CreateAsync(model);

            return this.Redirect("/");
        }

   
        public async Task<IActionResult> AllAuthors(AllAuthorsViewModel model)
        {
            var all = this.authorService.GetAll();
            return this.View(all);
        }
    }
}
