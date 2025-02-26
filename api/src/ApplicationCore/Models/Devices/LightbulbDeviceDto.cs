﻿using Homemap.ApplicationCore.Constants;
using System.Text.Json.Serialization;

namespace Homemap.ApplicationCore.Models.Devices
{
    [JsonDerivedType(typeof(LightbulbDeviceDto), DeviceConstants.LIGHTBULB)]
    public record LightbulbDeviceDto : DeviceDto
    {
    }
}
