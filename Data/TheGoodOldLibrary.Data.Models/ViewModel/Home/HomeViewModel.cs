namespace TheGoodOldLibrary.Data.Models.ViewModel.Home
{
    using System.Collections.Generic;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;
    using TheGoodOldLibrary.Data.Models.ViewModel.Periodical;

    public class HomeViewModel
    {
        public int UsersCount { get; set; }

        public int BooksCount { get; set; }

        public int PerodicalsCount { get; set; }

        public List<BookInListViewModel> Books { get; set; }

        public List<PeriodicalInListViewModel> Periodicals { get; set; }

    }
}
