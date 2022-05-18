namespace TheGoodOldLibrary.Data.Models
{
    using System;
    using TheGoodOldLibrary.Data.Common.Models;
    public class Reader : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
