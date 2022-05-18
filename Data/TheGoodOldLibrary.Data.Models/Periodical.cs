namespace TheGoodOldLibrary.Data.Models
{
    using System;
    using System.Collections.Generic;

    using TheGoodOldLibrary.Data.Common.Models;

    public class Periodical : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime PublicDate { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<Reader> Readers { get; set; } = new HashSet<Reader>();
    }
}
