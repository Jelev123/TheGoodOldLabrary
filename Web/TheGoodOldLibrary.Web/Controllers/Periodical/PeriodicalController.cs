namespace TheGoodOldLibrary.Web.Controllers.Periodical
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;
    using TheGoodOldLibrary.Data.Models.ViewModel.Periodical;
    using TheGoodOldLibrary.Services.Data.Author;
    using TheGoodOldLibrary.Services.Data.Periodical;
    using TheGoodOldLibrary.Services.Data.PeriodicalTaking;
    using TheGoodOldLibrary.Services.Data.Type;

    public class PeriodicalController : Controller
    {
        private readonly IPeriodicalService periodicalService;
        private readonly IAuthorService authorService;
        private readonly ITypeService typeService;
        private readonly IPeriodicalTakingService takingPeriodicalService;

        public PeriodicalController(IPeriodicalService periodicalService, ITypeService typeService, IAuthorService authorService, IPeriodicalTakingService takingPeriodicalService)
        {
            this.periodicalService = periodicalService;
            this.typeService = typeService;
            this.authorService = authorService;
            this.takingPeriodicalService = takingPeriodicalService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreatePeridiocalViewModel();
            viewModel.TypeItems = this.typeService.GetAllAsKeyValuePairs();
            viewModel.AuthorItems = this.authorService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePeridiocalViewModel model)
        {
            await this.periodicalService.CreateAsync(model);
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 9;

            var viewModel = new PeriodicalListViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                PeriodicalsCount = this.periodicalService.GetCount(),
                Periodicals = this.periodicalService.GetAll<PeriodicalInListViewModel>(id, 100),
            };
            return this.View(viewModel);
        }

        public IActionResult GetById(int id)
        {
            return this.View(this.periodicalService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PeriodicalTaking(TakingServiceModel takingServiceModel)
        {
            takingServiceModel.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.takingPeriodicalService.Create(takingServiceModel);

            return this.Redirect("All");
        }
    }
}