using Domain.DownloadableItems.Events;

namespace Domain.DownloadableItems;

public partial class DownloadableItem
{
    public void Evolve(IDomainEvent[] @events)
    {
        foreach (var @event in @events)
        {
            switch (@event)
            {
                case DownloadableItemInitiated initiated:
                    Evolve(initiated);
                    break;
                case DownloadableItemFinishedSuccessfully downloaded:
                    Evolve(downloaded);
                    break;
            }
        }
    }

    private void Evolve(DownloadableItemInitiated @event)
    {
        Id = @event.Id;
        Uri = @event.Uri;
    }

    private void Evolve(DownloadableItemFinishedSuccessfully @event)
    {
        Path = @event.Path;
    }
}