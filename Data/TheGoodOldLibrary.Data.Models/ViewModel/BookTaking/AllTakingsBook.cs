namespace TheGoodOldLibrary.Data.Models.ViewModel.BookTaking
{
    using System;
    using TheGoodOldLibrary.Data.Common.Models;
    using TheGoodOldLibrary.Data.Models;
    public class AllTakingsBook : BaseDeletableModel<string>
    {
        public string Id { get; set; }

        public string BookName { get; set; }

        public string BookTakingId { get; set; }

        public BookTaking BookTaking { get; set; }

        public DateTime ReturnAt { get; set; }

        public bool IsTaken { get; set; }

        public string UserName { get; set; }

    }
}
