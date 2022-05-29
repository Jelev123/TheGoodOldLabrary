namespace TheGoodOldLibrary.Data.Models
{
    using TheGoodOldLibrary.Data.Common.Models;
    using TheGoodOldLibrary.Services.Mapping;

    public class PeriodicalTaking : BaseDeletableModel<string>, IMapFrom<Periodical>
    {
        public int PeriodicalId { get; set; }

        public Periodical Periodical { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}