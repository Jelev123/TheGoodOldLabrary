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
            await dbContext.SaveChangesAsync();
        }
    }
}
