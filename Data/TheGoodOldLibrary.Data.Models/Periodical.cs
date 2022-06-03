namespace TheGoodOldLibrary.Data.Models
{
    using System.Collections.Generic;

    using TheGoodOldLibrary.Data.Common.Models;

    public class Periodical : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int TypeId { get; set; }

        public Types Type { get; set; }

        public string OriginalUrl { get; set; }

        public int PeriodicalCount { get; set; }

        public int OrderedTimes { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; } = new HashSet<ApplicationUser>();
    }
}
