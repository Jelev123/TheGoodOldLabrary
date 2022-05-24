namespace TheGoodOldLibrary.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class AuthorSeeder : ISeeder

    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Authors.Any())
            {
                return;
            }

            await dbContext.Authors.AddAsync(new Models.Author { Name = "Stiven" });

            await dbContext.SaveChangesAsync();

        }
    }
}
