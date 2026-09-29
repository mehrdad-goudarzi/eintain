using Domain.DownloadableItems.Events;

namespace Domain.DownloadableItems;

public partial class DownloadableItem
{
    public static DownloadableItem Initiate(Uri uri)
    {
        var item = new DownloadableItem();
        var initiated = new DownloadableItemInitiated(Guid.NewGuid(), uri);
        item.Evolve([initiated]);
        item._events.Add(initiated);
        return item;
    }

    public void FinishedSuccessfully(string path)
    {
        var initiated = new DownloadableItemFinishedSuccessfully(path);
        Evolve([initiated]);
        _events.Add(initiated);
    }
}