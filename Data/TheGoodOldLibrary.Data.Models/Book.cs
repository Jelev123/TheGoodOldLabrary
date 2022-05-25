namespace TheGoodOldLibrary.Data.Models
{
    using System;
    using System.Collections.Generic;

    using TheGoodOldLibrary.Data.Common.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;
    using TheGoodOldLibrary.Services.Mapping;

    public class Book : BaseDeletableModel<int>, IMapTo<BookViewModel>
    {
        public string Name { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public string UriginalUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int BookCount { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; } = new HashSet<ApplicationUser>();

        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();
    }
}
