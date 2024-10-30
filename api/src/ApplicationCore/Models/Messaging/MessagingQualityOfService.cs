namespace Homemap.ApplicationCore.Models.Messaging
{
    public enum MessagingQualityOfService
    {
        AT_MOST_ONCE = 0x00,
        AT_LEAST_ONCE = 0x01,
        EXACTLT_ONCE = 0x02
    }
}
