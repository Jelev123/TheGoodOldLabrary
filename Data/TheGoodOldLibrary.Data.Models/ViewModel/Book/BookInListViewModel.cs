namespace TheGoodOldLibrary.Data.Models.ViewModel.Book
{
    using System.Linq;

    using AutoMapper;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Services.Mapping;

    public class BookInListViewModel 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string GenreName { get; set; }

        public string AuthorName { get; set; }

        public int GenreId { get; set; }

        public string Images { get; set; }

       
    }
}
