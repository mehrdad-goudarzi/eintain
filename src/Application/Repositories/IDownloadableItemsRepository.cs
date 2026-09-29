using Domain.DownloadableItems;
using Domain.DownloadableItems.Events;

namespace Application.Repositories;

public interface IDownloadableItemsRepository
{
    Task<IEnumerable<DownloadableItem>> GetAll();
    Task Persist(string id, IReadOnlyCollection<IDomainEvent> events);
    Task<DownloadableItem> Load(string id);
}