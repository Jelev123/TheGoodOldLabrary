namespace TheGoodOldLibrary.Data.Models
{
    using System;
    using System.Collections.Generic;

    using TheGoodOldLibrary.Data.Common.Models;

    public class Book : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public string UriginalUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int BookCount { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; } = new HashSet<ApplicationUser>();

        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();
    }
}
