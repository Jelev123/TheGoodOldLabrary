namespace TheGoodOldLibrary.Web.Controllers.Periodical
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using TheGoodOldLibrary.Data.Models.ViewModel.Periodical;
    using TheGoodOldLibrary.Services.Data.Periodical;
    using TheGoodOldLibrary.Services.Data.Type;

    public class PeriodicalController : Controller
    {
        private readonly IPeriodicalService periodicalService;
        private readonly ITypeService typeService;

        public PeriodicalController(IPeriodicalService periodicalService, ITypeService typeService)
        {
            this.periodicalService = periodicalService;
            this.typeService = typeService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreatePeridiocalViewModel();
            viewModel.TypeItems = this.typeService.GetAllAsKeyValuePairs();
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
    }
}
