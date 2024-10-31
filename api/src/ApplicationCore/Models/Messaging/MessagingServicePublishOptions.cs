namespace Homemap.ApplicationCore.Models.Messaging
{
    public record MessagingServicePublishOptions
    {
        public MessagingQualityOfService QualityOfService { get; init; } = MessagingQualityOfService.AT_MOST_ONCE;

        public string ContentType { get; init; } = "application/json";

        public bool IsRetain { get; init; } = false;
    }
}
