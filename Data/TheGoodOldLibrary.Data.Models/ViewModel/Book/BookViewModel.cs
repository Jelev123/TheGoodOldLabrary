namespace TheGoodOldLibrary.Data.Models.ViewModel.Book
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GenreId { get; set; }

        public string GenreName { get; set; }

        public int AuthorId { get; set; }

        public int BookStatusId { get; set; }

        public string AuthorName { get; set; }

        public string ImageUrl { get; set; }
    }
}
