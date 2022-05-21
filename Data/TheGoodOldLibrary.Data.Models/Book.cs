namespace TheGoodOldLibrary.Data.Models
{
    using System.Collections.Generic;

    using TheGoodOldLibrary.Data.Common.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;
    using TheGoodOldLibrary.Services.Mapping;

    public class Book : BaseDeletableModel<int>, IMapTo<BookInListViewModel>
    {
        public string Name { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public string UriginalUrl { get; set; }

        public virtual ICollection<Reader> Readers { get; set; } = new HashSet<Reader>();

        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();
    }
}
