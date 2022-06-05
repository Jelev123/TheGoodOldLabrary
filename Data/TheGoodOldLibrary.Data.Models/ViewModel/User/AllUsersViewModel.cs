namespace TheGoodOldLibrary.Data.Models.ViewModel.User
{
    using TheGoodOldLibrary.Data.Common.Models;

    public class AllUsersViewModel : BaseDeletableModel<string>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
