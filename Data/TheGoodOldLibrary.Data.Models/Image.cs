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

        public virtual Book Books { get; set; }

        public string Extension { get; set; }

      

    }
}
