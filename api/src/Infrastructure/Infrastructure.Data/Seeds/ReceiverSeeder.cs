using Homemap.ApplicationCore.Interfaces.Seeders;
using Homemap.Domain.Core;
using Homemap.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Homemap.Infrastructure.Data.Seeds
{
    public class ReceiverSeeder : BaseSeeder<Receiver>, ISeeder
    {
        public ReceiverSeeder(ApplicationDbContext context) : base(context)
        {
        }

        private static string GenerateRandomName()
        {
            return $"Receiver {Guid.NewGuid()}";
        }

        public async Task SeedAsync()
        {
            if (await _entities.AnyAsync())
                return;

            List<Receiver> receivers = [
                new Receiver()
                {
                    Name = GenerateRandomName(),
                    ProjectId = 1,
                },
                new Receiver()
                {
                    Name = "My custom receiver",
                    ProjectId = 1,
                },
                new Receiver()
                {
                    Name = GenerateRandomName(),
                    ProjectId = 2,
                },
            ];

            await _entities.AddRangeAsync(receivers);
            await _context.SaveChangesAsync();
        }
    }
}
