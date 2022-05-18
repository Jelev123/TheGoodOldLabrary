namespace TheGoodOldLibrary.Services.Data.Book
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Web.ViewModels.Books;

    public class BookService : IBookService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Book> bookRepository;

        public BookService(IDeletableEntityRepository<Book> bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task CreateAsync(CreateBooksViewModel model, int authorId, string imagePath)
        {
            var book = new Book
            {
                Name = model.Name,
                GenreId = model.GenreId,
                AuthorId = model.AuthorId,

            };

            Directory.CreateDirectory($"{imagePath}/books/");
            foreach (var image in model.Image)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');

                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    Extension = extension,
                    AuthorId = authorId,
                };
                book.Images.Add(dbImage);

                await this.bookRepository.AddAsync(book);
                await this.bookRepository.SaveChangesAsync();

                var physicalPath = $"{imagePath}/recipes/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }
        }
    }
}
