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

                 new Project()
                {
                    Name = "Home - second floor"
                },
                 new Project()
                {
                    Name = "Cottage - sauna"
                },
                new Project()
                {
                    Name = "Cottage - main house"
                },
                 new Project()
                {
                    Name = "Cabin"
                },
                 new Project()
                {
                    Name = "Office"
                },
                new Project()
                {
                    Name = "Guest room"
                },
                new Project()
                {
                    Name = "Farmhouse - kitchen"
                },
                new Project()
                {
                    Name = "Father's room"
                },
                new Project()
                {
                    Name = "Mother's room"
                },
            ];

            await _entities.AddRangeAsync(projects);
            await _context.SaveChangesAsync();
        }
    }
}
