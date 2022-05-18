namespace TheGoodOldLibrary.Data.Models
{
    using System.Collections.Generic;
    using TheGoodOldLibrary.Data.Common.Models;

    public class Author : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
        public ICollection<Periodical> Periodicals { get; set; } = new HashSet<Periodical>();
    }
}
