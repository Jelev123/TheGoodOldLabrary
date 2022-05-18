namespace TheGoodOldLibrary.Data.Models
{
    using System.Collections.Generic;

    using TheGoodOldLibrary.Data.Common.Models;

    public class Book : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<Reader> Readers { get; set; } = new HashSet<Reader>();

        public ICollection<Image> Images { get; set; } = new HashSet<Image>();
    }
}
