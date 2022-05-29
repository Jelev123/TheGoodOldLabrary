namespace TheGoodOldLibrary.Data.Models.ViewModel.Periodical
{
    public class PeriodicalInListViewModel : PeriodicalTaking
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TypeName { get; set; }

        public string Image { get; set; }

        public int BookStatusId { get; set; }
    }
}
