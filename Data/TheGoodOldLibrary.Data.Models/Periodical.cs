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

        public virtual ICollection<Reader> Readers { get; set; } = new HashSet<Reader>();

        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();
    }
}
