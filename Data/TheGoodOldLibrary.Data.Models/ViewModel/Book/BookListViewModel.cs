namespace TheGoodOldLibrary.Data.Models.ViewModel.Book
{
    using System.Collections.Generic;
    using TheGoodOldLibrary.Web.ViewModels;

    public class BookListViewModel : PagingViewModel
    {
        public virtual IEnumerable<BookInListViewModel> Books { get; set; }

    }
}
