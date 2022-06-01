namespace TheGoodOldLibrary.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class GenreSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Genres.Any())
            {
                return;
            }

            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Thriller" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Comedy" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Literary Fiction" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Mystery" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Horror" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Historical" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Romance" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Western" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Bildungsroman" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Speculative Fiction" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Science Fiction" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Fantasy" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Dystopian" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Magical Realism" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Memoir" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Politics" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Self-Help" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Crime Thriller" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Literary Fiction" });
            await dbContext.SaveChangesAsync();
        }
    }
}
