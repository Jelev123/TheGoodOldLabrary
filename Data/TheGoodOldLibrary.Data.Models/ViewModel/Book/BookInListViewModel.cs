namespace TheGoodOldLibrary.Data.Models.ViewModel.Book
{
    public class BookInListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string GenreName { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        public string Images { get; set; }

    }
}
