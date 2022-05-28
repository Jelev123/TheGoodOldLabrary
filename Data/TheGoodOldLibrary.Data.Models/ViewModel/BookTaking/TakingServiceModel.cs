namespace TheGoodOldLibrary.Data.Models.ViewModel.BookTaking
{
    using TheGoodOldLibrary.Data.Models;

    public class TakingServiceModel
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int PeriodicalId { get; set; }

        public string UserId { get; set; }

        public int BookStatusId { get; set; }

    }
}
