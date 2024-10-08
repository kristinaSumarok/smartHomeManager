using Homemap.ApplicationCore.Interfaces.Seeders;
using Homemap.Domain.Core;
using Homemap.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Homemap.Infrastructure.Data.Seeds;

public class DeviceSeeder : BaseSeeder<Device>, ISeeder {
    public DeviceSeeder(ApplicationDbContext context) : base(context) {
    }

    public Task SeedAsync() {
        throw new NotImplementedException();
    }
}

