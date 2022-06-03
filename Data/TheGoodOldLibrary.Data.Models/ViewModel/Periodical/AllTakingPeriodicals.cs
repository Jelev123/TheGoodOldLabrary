namespace TheGoodOldLibrary.Data.Models.ViewModel.Periodical
{
    using System;
    using TheGoodOldLibrary.Data.Common.Models;

    public class AllTakingPeriodicals : BaseDeletableModel<string>
    {
        public string Id { get; set; }

        public string PriodicalName { get; set; }

        public string PeriodicalTakingId { get; set; }

        public PeriodicalTaking PeriodicalTaking { get; set; }

        public DateTime ReturnAt { get; set; }

        public bool IsTaken { get; set; }

        public string UserName { get; set; }
    }
}
