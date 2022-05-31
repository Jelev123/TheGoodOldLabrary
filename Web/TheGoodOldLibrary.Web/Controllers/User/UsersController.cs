namespace TheGoodOldLibrary.Web.Controllers.User
{
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Models.ViewModel.User;
    using TheGoodOldLibrary.Services.Data.User;

    public class UsersController : Controller
    {
        private readonly IUserService usersService;

        public UsersController(IUserService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<IActionResult> Delete(AllUsersViewModel model)
        {
            model.Id = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.usersService.DeleteAsync(model);

            return this.Redirect("/");
        }

        public async Task<IActionResult> AllUsers()
        {
            var all = this.usersService.All();

            return this.View(all);
        }
    }
}
