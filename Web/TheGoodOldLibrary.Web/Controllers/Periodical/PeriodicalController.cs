﻿namespace TheGoodOldLibrary.Web.Controllers.Periodical
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;
    using TheGoodOldLibrary.Data.Models.ViewModel.Periodical;
    using TheGoodOldLibrary.Services.Data.Author;
    using TheGoodOldLibrary.Services.Data.Library;
    using TheGoodOldLibrary.Services.Data.Periodical;
    using TheGoodOldLibrary.Services.Data.PeriodicalTaking;
    using TheGoodOldLibrary.Services.Data.Type;

    public class PeriodicalController : Controller
    {
        private readonly IPeriodicalService periodicalService;
        private readonly IAuthorService authorService;
        private readonly ITypeService typeService;
        private readonly ILabraryService labraryService;
        private readonly IPeriodicalTakingService takingPeriodicalService;

        public PeriodicalController(IPeriodicalService periodicalService, ITypeService typeService, IAuthorService authorService, IPeriodicalTakingService takingPeriodicalService, ILabraryService labraryService)
        {
            this.periodicalService = periodicalService;
            this.typeService = typeService;
            this.authorService = authorService;
            this.takingPeriodicalService = takingPeriodicalService;
            this.labraryService = labraryService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreatePeridiocalViewModel
            {
                TypeItems = this.typeService.GetAllAsKeyValuePairs(),
                Authors = this.authorService.GetAll(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePeridiocalViewModel model)
        {
            await this.periodicalService.CreateAsync(model);
            return this.RedirectToAction("All");
        }

        public IActionResult Update(int id)
        {
            var inputModel = this.periodicalService.GetById<PeriodicalInListViewModel>(id);
            inputModel.TypeItems = this.typeService.GetAllAsKeyValuePairs();
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, PeriodicalInListViewModel input)
        {
            await this.periodicalService.UpdateAsync(input, id);

            return this.RedirectToAction(nameof(this.GetById), new { id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.labraryService.DeleteAsync(id);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 9;

            return this.View(new PeriodicalListViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                PeriodicalsCount = this.labraryService.GetCount(),
                Periodicals = this.labraryService.GetAll<PeriodicalInListViewModel>(id, 100),
            });
        }

        public IActionResult GetById(int id)
        {
            return this.View(this.periodicalService.GetById<PeriodicalInListViewModel>(id));
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