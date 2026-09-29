namespace Domain.DownloadableItems.Events;

public record DownloadableItemFinishedSuccessfully(string Path) : IDomainEvent;