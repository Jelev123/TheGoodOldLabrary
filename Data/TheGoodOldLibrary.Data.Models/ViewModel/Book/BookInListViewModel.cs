namespace TheGoodOldLibrary.Data.Models.ViewModel.Book
{
    using System.Linq;

    using AutoMapper;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Services.Mapping;

    public class BookInListViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string GenreName { get; set; }

        public string AuthorName { get; set; }

        public int GenreId { get; set; }

        public string Images { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, BookInListViewModel>()
                .ForMember(x => x.Images, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().Images != null ?
                        x.Images.FirstOrDefault().Images :
                        "/images/book/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
