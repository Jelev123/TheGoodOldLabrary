namespace TheGoodOldLibrary.Data.Models
{
    using System;

    using TheGoodOldLibrary.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int BookId { get; set; }

        public string RemoteImageUrl { get; set; }

        public Book Books { get; set; }

        public int PeriodicalId { get; set; }

        public Periodical Periodical { get; set; }

        public string Extension { get; set; }

    }
}
