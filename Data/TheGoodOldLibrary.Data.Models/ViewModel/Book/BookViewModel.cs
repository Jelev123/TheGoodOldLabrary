namespace TheGoodOldLibrary.Data.Models.ViewModel.Book
{
    using System.Collections.Generic;

    public class BookViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GenreId { get; set; }

        public string GenreName { get; set; }

        public int AuthorId { get; set; }

        public int BookStatusId { get; set; }

        public int BookCount { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GenreItems { get; set; }

    }
}
