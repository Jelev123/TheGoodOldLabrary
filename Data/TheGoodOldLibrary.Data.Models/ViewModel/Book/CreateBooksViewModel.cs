namespace TheGoodOldLibrary.Data.Models.ViewModel.Book
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateBooksViewModel
    {
        public string Name { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Display(Name = "Author")]

        public int AuthorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GenreItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> AuthorItems { get; set; }

        public string Image { get; set; }
    }
}
