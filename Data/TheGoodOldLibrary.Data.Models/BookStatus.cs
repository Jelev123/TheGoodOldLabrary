namespace TheGoodOldLibrary.Data.Models
{
    using TheGoodOldLibrary.Data.Common.Models;

    public class BookStatus : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
