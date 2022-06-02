namespace TheGoodOldLibrary.Data.Models
{
    using System;
    using TheGoodOldLibrary.Data.Common.Models;

    public class BookTaking : BaseDeletableModel<string>
    {
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public bool IsTaken { get; set; }

        public DateTime ReturnAt { get; set; }
    }
}
