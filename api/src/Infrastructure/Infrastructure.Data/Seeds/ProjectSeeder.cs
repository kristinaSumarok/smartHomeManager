using Homemap.ApplicationCore.Interfaces.Seeders;
using Homemap.Domain.Core;
using Homemap.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Homemap.Infrastructure.Data.Seeds
{
    public class ProjectSeeder : BaseSeeder<Project>, ISeeder
    {
        public ProjectSeeder(ApplicationDbContext context) : base(context)
        {
        }

        public async Task SeedAsync()
        {
            if (await _entities.AnyAsync())
                return;

            List<Project> projects = [
                new Project()
                {
                    Name = "Dad's garage",
                },
                new Project()
                {
                    Name = "Home - ground floor"
                },
            ];

            await _entities.AddRangeAsync(projects);
            await _context.SaveChangesAsync();
        }
    }
}
