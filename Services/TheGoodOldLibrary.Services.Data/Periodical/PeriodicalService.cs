namespace TheGoodOldLibrary.Services.Data.Periodical
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;
    using TheGoodOldLibrary.Web.ViewModels.Peridiocal;

    public class PeriodicalService : IPeriodicalService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Periodical> periodicalRepository;

        public PeriodicalService(IDeletableEntityRepository<Periodical> periodicalRepository)
        {
            this.periodicalRepository = periodicalRepository;
        }

        public async Task CreateAsync(CreatePeridiocalViewModel model, string imagePath)
        {
            var periodical = new Periodical
            {
                Name = model.Name,
                TypeId = model.TypeId,
            };

            Directory.CreateDirectory($"{imagePath}/periodicals/");

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
                periodical.Images.Add(dbImage);

                await this.periodicalRepository.AddAsync(periodical);
                await this.periodicalRepository.SaveChangesAsync();

                var physicalPath = $"{imagePath}/periodical/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }
        }
    }
}
