namespace TheGoodOldLibrary.Services.Data.User
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.User;

    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> userRepository;

        public UserService(IRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<AllUsersViewModel> All()
        {
           return this.userRepository.AllAsNoTracking()
                .Select(s => new AllUsersViewModel
                {
                    Id = s.Id,
                    Name = s.UserName,
                }).ToList();
        }

        public async Task DeleteAsync(AllUsersViewModel model)
        {
            var user = this.userRepository.AllAsNoTracking().FirstOrDefault(s => s.Id == model.Id);
            this.userRepository.Delete(user);
            await this.userRepository.SaveChangesAsync();
        }
    }
}
