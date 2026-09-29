using Domain.DownloadableItems.Events;

namespace Domain.DownloadableItems;

public partial class DownloadableItem
{
    private readonly List<IDomainEvent> _events = new();
    public Guid Id { get; private set; }
    private Uri Uri { get; set; }
    public string? Path { get; set; }
    public IReadOnlyCollection<IDomainEvent> Events => _events.AsReadOnly();
}