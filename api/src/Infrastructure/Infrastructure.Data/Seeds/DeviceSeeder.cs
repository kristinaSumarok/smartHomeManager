using Homemap.ApplicationCore.Interfaces.Seeders;
using Homemap.Domain.Core;
using Homemap.Domain.Devices;
using Homemap.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Homemap.Infrastructure.Data.Seeds;

public class DeviceSeeder : BaseSeeder<Device>, ISeeder
{
    private static int _idxCount = 0;

    public DeviceSeeder(ApplicationDbContext context) : base(context)
    {
    }

    private static string GenerateRandomDeviceName(Type deviceType)
    {
        _idxCount++;
        return $"{deviceType.Name.ToString().ToLower()} nr {_idxCount}";
    }

    public async Task SeedAsync()
    {
        if (await _entities.AnyAsync())
            return;

        List<Device> Devices = [
            new LightbulbDevice()
            {
                Name = GenerateRandomDeviceName(typeof(LightbulbDevice)),
                ReceiverId = 2,
            },
            new LightbulbDevice()
            {
                Name = GenerateRandomDeviceName(typeof(LightbulbDevice)),
                ReceiverId = 2,
            },
            new SocketDevice()
            {
                Name = GenerateRandomDeviceName(typeof(SocketDevice)),
                ReceiverId = 2,
            },
            new LightbulbDevice()
            {
                Name = GenerateRandomDeviceName(typeof(LightbulbDevice)),
                ReceiverId = 4,
            },
            new ThermostatDevice()
            {
                Name = GenerateRandomDeviceName(typeof(ThermostatDevice)),
                ReceiverId = 4,
            },
            new ACDevice()
            {
                Name = GenerateRandomDeviceName(typeof(ACDevice)),
                ReceiverId = 1,
            },
            new LightbulbDevice()
            {
                Name = GenerateRandomDeviceName(typeof(LightbulbDevice)),
                ReceiverId = 1,
            },
            new SocketDevice()
            {
                Name = GenerateRandomDeviceName(typeof(SocketDevice)),
                ReceiverId = 5,
            },
            new ThermostatDevice()
            {
                Name = GenerateRandomDeviceName(typeof(ThermostatDevice)),
                ReceiverId = 3,
            },
        ];

        await _entities.AddRangeAsync(Devices);
        await _context.SaveChangesAsync();
    }
}

