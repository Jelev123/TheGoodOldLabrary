namespace TheGoodOldLibrary.Services.Data.Author
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Models.ViewModel.Author;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;

    public interface IAuthorService
    {
        Task CreateAsync(CreateAuthorViewModel model);

        IEnumerable<AllAuthorsViewModel> GetAll();

    }
}
