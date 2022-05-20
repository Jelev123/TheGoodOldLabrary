namespace TheGoodOldLibrary.Data.Models
{
    using System.Collections.Generic;

    using TheGoodOldLibrary.Data.Common.Models;

    public class Book : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public virtual ICollection<Reader> Readers { get; set; } = new HashSet<Reader>();

        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();
    }
}
