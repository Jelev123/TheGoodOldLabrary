namespace TheGoodOldLibrary.Web.Controllers.TakingPeriodicalController
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;
    using TheGoodOldLibrary.Data.Models.ViewModel.Periodical;
    using TheGoodOldLibrary.Services.Data.PeriodicalTaking;

    public class PeriodicalTakenController : Controller
    {
        private readonly IPeriodicalTakingService periodicalTakingService;

        public PeriodicalTakenController(IPeriodicalTakingService bookTakingService)
        {
            this.periodicalTakingService = bookTakingService;
        }

        [HttpPost]
        public async Task<IActionResult> PeriodicalTaking(TakingServiceModel takingServiceModel)
        {
            takingServiceModel.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.periodicalTakingService.Create(takingServiceModel);

            return this.Redirect("/");
        }

        public IActionResult GeTAllOrderedByUser(string id)
        {
            var all = this.periodicalTakingService.GetOrders<AllTakings>(id, true);

            var allReturned = this.periodicalTakingService.GetOrders<AllTakings>(id, false);

            var allIn = all.Concat(allReturned).ToList();

            return this.View(allIn);
        }

        [Route("PeriodicalTaking/Return/{orderedId}")]
        [HttpGet]
        public IActionResult Return(string orderedId)
        {
            this.periodicalTakingService.Return<AllTakings>(orderedId);

            return this.Redirect("/");
        }
    }
}
