namespace TheGoodOldLibrary.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class TypeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Types.Any())
            {
                return;
            }

            await dbContext.Types.AddAsync(new Models.Types { Name = "Sport"});
            await dbContext.Types.AddAsync(new Models.Types { Name = "Newspapers" });
            await dbContext.Types.AddAsync(new Models.Types { Name = "Nature"});
            await dbContext.Types.AddAsync(new Models.Types { Name = "Planet"});
            await dbContext.Types.AddAsync(new Models.Types { Name = "Audience" });
            await dbContext.Types.AddAsync(new Models.Types { Name = "Authorship" });
            await dbContext.Types.AddAsync(new Models.Types { Name = "Documentation" });
            await dbContext.Types.AddAsync(new Models.Types { Name = "Appearance" });
            await dbContext.SaveChangesAsync();
        }
    }
}
