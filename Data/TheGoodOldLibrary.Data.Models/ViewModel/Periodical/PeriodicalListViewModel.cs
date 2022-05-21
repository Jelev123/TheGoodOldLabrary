namespace TheGoodOldLibrary.Data.Models.ViewModel.Periodical
{
    using System.Collections.Generic;

    public class PeriodicalListViewModel : PagingPeriodicalsViewModel
    {
        public IEnumerable<PeriodicalInListViewModel> Periodicals { get; set; }
    }
}
