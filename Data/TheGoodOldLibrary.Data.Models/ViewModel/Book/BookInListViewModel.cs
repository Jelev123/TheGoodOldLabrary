namespace TheGoodOldLibrary.Data.Models.ViewModel.Book
{
    public class BookInListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string GenreName { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        public string Images { get; set; }

        public int BooksCount { get; set; }

        public int OrderedTimes { get; set; }
    }
}
