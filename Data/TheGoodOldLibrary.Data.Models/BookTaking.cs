namespace TheGoodOldLibrary.Data.Models
{
    using TheGoodOldLibrary.Data.Common.Models;

    public class BookTaking : BaseDeletableModel<string>
    {
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public int BookStatusId { get; set; }

        public virtual BookStatus BookStatus { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
