using Homemap.ApplicationCore.Interfaces.Seeders;
using Homemap.Domain.Core;
using Homemap.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Homemap.Infrastructure.Data.Seeds;

public class DeviceSeeder : BaseSeeder<Device>, ISeeder {
    private static int idx_count = 0;
    public DeviceSeeder(ApplicationDbContext context) : base(context) {
    }

    private static string GenerateRandomDevice(DeviceType type) {
        idx_count++;
        return $"{type.ToString().ToLower()} nr {idx_count}";
    }

    public async Task SeedAsync() {
        if (await _entities.AnyAsync())
            return;

        List<Device> Devices = [
            new Device()
                {
                    Name = GenerateRandomDevice(DeviceType.LIGHTBULB),
                    ReceiverId = 2,
                    DeviceType= DeviceType.LIGHTBULB,
                },
            new Device()
                {
                    Name = GenerateRandomDevice(DeviceType.LIGHTBULB),
                    ReceiverId = 2,
                    DeviceType= DeviceType.LIGHTBULB,
                },
            new Device()
                {
                    Name = GenerateRandomDevice(DeviceType.SOCKET),
                    ReceiverId = 2,
                    DeviceType= DeviceType.SOCKET,
                },
            new Device()
                {
                    Name = GenerateRandomDevice(DeviceType.LIGHTBULB),
                    ReceiverId = 4,
                    DeviceType= DeviceType.LIGHTBULB,
                },
            new Device()
                {
                    Name = GenerateRandomDevice(DeviceType.THERMOSTAT),
                    ReceiverId = 4,
                    DeviceType= DeviceType.THERMOSTAT,
                },
            new Device()
                {
                    Name = GenerateRandomDevice(DeviceType.AC),
                    ReceiverId = 1,
                    DeviceType= DeviceType.AC,
                },
            new Device()
                {
                    Name = GenerateRandomDevice(DeviceType.LIGHTBULB),
                    ReceiverId = 1,
                    DeviceType= DeviceType.LIGHTBULB,
                },
            new Device()
                {
                    Name = GenerateRandomDevice(DeviceType.SOCKET),
                    ReceiverId = 5,
                    DeviceType= DeviceType.SOCKET,
                },
            new Device()
                {
                    Name = GenerateRandomDevice(DeviceType.THERMOSTAT),
                    ReceiverId = 3,
                    DeviceType= DeviceType.THERMOSTAT,
                },
            ];
        await _entities.AddRangeAsync(Devices);
        await _context.SaveChangesAsync();
    }
}

