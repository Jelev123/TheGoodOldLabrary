namespace TheGoodOldLibrary.Services.Data.Book
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Services.Mapping;
    using TheGoodOldLibrary.Web.ViewModels.Books;

    public class BookService : IBookService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Book> bookRepository;

        public BookService(IDeletableEntityRepository<Book> bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task CreateAsync(CreateBooksViewModel model, string imagePath)
        {
            var book = new Book
            {
                Name = model.Name,
                GenreId = model.GenreId,
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
                };
                book.Images.Add(dbImage);

                await this.bookRepository.AddAsync(book);
                await this.bookRepository.SaveChangesAsync();

                var physicalPath = $"{imagePath}/book/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 2)
        {
            var book = this.bookRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();
            return book;
        }

        public int GetCount()
        {
            return this.bookRepository.All().Count();
        }
    }
}
