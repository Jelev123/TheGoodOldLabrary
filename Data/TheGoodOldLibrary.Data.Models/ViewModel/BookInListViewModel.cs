namespace TheGoodOldLibrary.Data.Models.ViewModel
{
    using AutoMapper;
    using System.Linq;
    using TheGoodOldLibrary.Services.Mapping;

    public class BookInListViewModel : IMapTo<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Image { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, BookInListViewModel>()
                .ForMember(x => x.Image, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/images/book/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
