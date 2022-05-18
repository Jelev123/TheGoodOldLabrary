namespace TheGoodOldLibrary.Web.ViewModels.Books
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Http;

    public class CreateBooksViewModel
    {
        public string Name { get; set; }

        public int GenreId { get; set; }

        public int AuthorId { get; set; }

        public IEnumerable<IFormFile> Image { get; set; }
    }
}
