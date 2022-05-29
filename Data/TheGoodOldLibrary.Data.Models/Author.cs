namespace TheGoodOldLibrary.Data.Models
{
    using System.Collections.Generic;

    using TheGoodOldLibrary.Data.Common.Models;

    public class Author : BaseDeletableModel<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();

        public virtual ICollection<Periodical> Periodicals { get; set; } = new HashSet<Periodical>();
    }
}
