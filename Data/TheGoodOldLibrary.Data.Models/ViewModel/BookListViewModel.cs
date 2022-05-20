namespace TheGoodOldLibrary.Data.Models.ViewModel
{
    using System.Collections.Generic;
    using TheGoodOldLibrary.Services.Mapping;
    using TheGoodOldLibrary.Web.ViewModels;

    public class BookListViewModel : PagingViewModel
    {
        public virtual IEnumerable<BookInListViewModel> Books { get; set; }

    }
}
