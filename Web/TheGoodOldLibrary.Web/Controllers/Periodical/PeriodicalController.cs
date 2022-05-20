namespace TheGoodOldLibrary.Web.Controllers.Periodical
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Services.Data.Periodical;
    using TheGoodOldLibrary.Services.Data.Type;
    using TheGoodOldLibrary.Web.ViewModels.Peridiocal;

    public class PeriodicalController : Controller
    {
        private readonly IPeriodicalService periodicalService;
        private readonly IWebHostEnvironment environment;
        private readonly ITypeService typeService;

        public PeriodicalController(IPeriodicalService periodicalService, IWebHostEnvironment environment, ITypeService typeService)
        {
            this.periodicalService = periodicalService;
            this.environment = environment;
            this.typeService = typeService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreatePeridiocalViewModel();
            viewModel.GenreItems = this.typeService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePeridiocalViewModel model)
        {
            await this.periodicalService.CreateAsync(model, $"{this.environment.WebRootPath}/images");

            return this.RedirectToAction("All");
        }
    }
}
