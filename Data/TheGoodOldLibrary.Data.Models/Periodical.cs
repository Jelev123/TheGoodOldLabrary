namespace TheGoodOldLibrary.Data.Models
{
    using System;
    using System.Collections.Generic;

    using TheGoodOldLibrary.Data.Common.Models;

    public class Periodical : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public DateTime PublicDate { get; set; }

        public int TypeId { get; set; }

        public Types Type { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PeriodicalCount { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; } = new HashSet<ApplicationUser>();

        public virtual ICollection<BookTaking> BookTakings { get; set; } = new HashSet<BookTaking>();


    }
}
