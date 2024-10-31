namespace Infrastructure.Messaging.Models
{
    internal record MessagingServiceOptions
    {
        public required string ConnectionUri { get; init; }
    }
}
