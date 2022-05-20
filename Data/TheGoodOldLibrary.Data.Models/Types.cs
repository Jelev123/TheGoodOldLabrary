namespace TheGoodOldLibrary.Data.Models
{
    using System.Collections.Generic;

    using TheGoodOldLibrary.Data.Common.Models;

    public class Types : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public ICollection<Periodical> Periodicals { get; set; }
    }
}
