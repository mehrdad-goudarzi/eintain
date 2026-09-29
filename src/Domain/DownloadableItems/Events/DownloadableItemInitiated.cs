namespace Domain.DownloadableItems.Events;

public record DownloadableItemInitiated(Guid Id, Uri Uri) : IDomainEvent;