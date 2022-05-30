namespace TheGoodOldLibrary.Data.Models.ViewModel.Periodical
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TheGoodOldLibrary.Data.Models.ViewModel.Author;

    public class CreatePeridiocalViewModel
    {
        public string Name { get; set; }

        [Display(Name = "Type")]

        public int TypeId { get; set; }

        [Display(Name = "Author")]

        public int AuthorId { get; set; }

        public int PeriodicalCount { get; set; }

        public string Image { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TypeItems { get; set; }

        public IEnumerable<AllAuthorsViewModel> Authors { get; set; }
    }
}
