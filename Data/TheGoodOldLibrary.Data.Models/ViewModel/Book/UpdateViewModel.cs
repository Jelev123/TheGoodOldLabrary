namespace TheGoodOldLibrary.Data.Models.ViewModel.Book
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UpdateViewModel
    {
        public string Name { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public int BookId { get; set; }

        public string BookName { get; set; }

        public int BookCount { get; set; }

        public int AuthorId { get; set; }

        public string Image { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GenreItems { get; set; }

    }
}
