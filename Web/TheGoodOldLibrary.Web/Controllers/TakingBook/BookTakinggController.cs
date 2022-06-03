namespace TheGoodOldLibrary.Web.Controllers.TakingBook
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;
    using TheGoodOldLibrary.Services.Data.BookTaking;

    public class BookTakinggController : Controller
    {
        private readonly IBookTakingService bookTakingService;

        public BookTakinggController(IBookTakingService bookTakingService)
        {
            this.bookTakingService = bookTakingService;
        }

        [HttpPost]
        public async Task<IActionResult> BookTaking(TakingServiceModel takingServiceModel)
        {
            takingServiceModel.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.bookTakingService.Create(takingServiceModel);

            return this.Redirect("/");
        }

        public IActionResult GeTAllOrderedByUser(string id)
        {
            var all = this.bookTakingService.GetOrders<AllTakings>(id, true);

            var allReturned = this.bookTakingService.GetOrders<AllTakings>(id,false);

            var allIn = all.Concat(allReturned).ToList();

            return this.View(allIn);
        }

        [Route("BookTakingg/Return/{orderedId}")]
        [HttpGet]
        public IActionResult Return(string orderedId)
        {
           this.bookTakingService.Return<AllTakings>(orderedId);

           return this.Redirect("/");
        }
    }
}
