namespace TheGoodOldLibrary.Data.Models.ViewModel.Periodical
{
    using System.Collections.Generic;

    public class PeriodicalListViewModel : PagingPeriodicalsViewModel
    {
        public virtual IEnumerable<PeriodicalInListViewModel> Periodicals { get; set; }


    }
}
