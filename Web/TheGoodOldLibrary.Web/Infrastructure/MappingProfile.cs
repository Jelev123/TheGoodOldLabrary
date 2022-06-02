namespace TheGoodOldLibrary.Web.Infrastructure
{
    using AutoMapper;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Data.Models.ViewModel.Book;
    using TheGoodOldLibrary.Data.Models.ViewModel.BookTaking;
    using TheGoodOldLibrary.Data.Models.ViewModel.Periodical;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Book, PeriodicalInListViewModel>();
            this.CreateMap<Book, BookInListViewModel>();
            this.CreateMap<Book, BookViewModel>();
            this.CreateMap<Periodical, BookInListViewModel>();
            this.CreateMap<Periodical, PeriodicalInListViewModel>();
            this.CreateMap<Periodical, PeriodicalListViewModel>();
            this.CreateMap<BookTaking, AllTakingsBook>();
        }
    }
}
