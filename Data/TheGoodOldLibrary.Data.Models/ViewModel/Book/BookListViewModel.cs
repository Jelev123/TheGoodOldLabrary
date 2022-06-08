namespace TheGoodOldLibrary.Data.Models.ViewModel.Book
{
    using System.Collections.Generic;
    using System.Linq;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;
    using TheGoodOldLibrary.Web.ViewModels;

    public class BookListViewModel : PagingViewModel
    {
        public virtual IEnumerable<BookInListViewModel> Books { get; set; }

        public IEnumerable<KeyValuePair<int, int>> TopOrders { get; set; }

    }
}
