namespace TheGoodOldLibrary.Data.Models.ViewModel.Periodical
{
    using System.Collections.Generic;

    public class PeriodicalInListViewModel : PeriodicalTaking
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TypeName { get; set; }

        public int TypeId { get; set; }

        public int AuthorId { get; set; }

        public string ImageUrl { get; set; }

        public int PeriodicalCount { get; set; }

        public int BookStatusId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TypeItems { get; set; }

    }
}
