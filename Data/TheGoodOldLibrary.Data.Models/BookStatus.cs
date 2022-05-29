namespace TheGoodOldLibrary.Data.Models
{
    using System.Collections.Generic;
    using TheGoodOldLibrary.Data.Common.Models;

    public class BookStatus : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public virtual ICollection<BookTaking> BookTakings { get; set; } = new HashSet<BookTaking>();

    }
}
