namespace TheGoodOldLibrary.Services.Data.User
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Models.ViewModel.User;

    public interface IUserService
    {
        IEnumerable<AllUsersViewModel> All();

        Task DeleteAsync(AllUsersViewModel model);
    }
}
