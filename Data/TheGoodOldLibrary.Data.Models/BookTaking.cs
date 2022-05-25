namespace TheGoodOldLibrary.Data.Models
{
    using TheGoodOldLibrary.Data.Common.Models;

    public class BookTaking : BaseModel<string>
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int PeriodicalId { get; set; }

        public Periodical Periodical { get; set; }

        public int BookStatusId { get; set; }

        public BookStatus BookStatus { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
