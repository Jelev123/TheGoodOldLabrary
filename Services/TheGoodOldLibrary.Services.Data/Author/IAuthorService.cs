namespace TheGoodOldLibrary.Services.Data.Author
{
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Models.ViewModel.Author;

    public interface IAuthorService
    {
        Task CreateAsync(CreateAuthorViewModel model);

    }
}
