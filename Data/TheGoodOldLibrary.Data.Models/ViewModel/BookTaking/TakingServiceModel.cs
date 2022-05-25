﻿namespace TheGoodOldLibrary.Data.Models.ViewModel.BookTaking
{
    using TheGoodOldLibrary.Data.Models;

    public class TakingServiceModel
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int PeriodicalId { get; set; }

        public Book Book { get; set; }

        public Periodical Periodical { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int BookStatusId { get; set; }

        public BookStatus BookStatus { get; set; }
    }
}
