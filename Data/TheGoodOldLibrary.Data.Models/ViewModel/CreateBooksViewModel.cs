namespace TheGoodOldLibrary.Web.ViewModels.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using TheGoodOldLibrary.Data.Models;

    public class CreateBooksViewModel
    {
        public string Name { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GenreItems { get; set; }

        public IEnumerable<IFormFile> Image { get; set; }
    }
}
