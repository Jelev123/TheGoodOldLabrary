namespace TheGoodOldLibrary.Data.Models.ViewModel.Book
{
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Services.Mapping;

    public class BookViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GenreId { get; set; }

        public string GenreName { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }
    }
}
