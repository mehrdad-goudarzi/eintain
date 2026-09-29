using Application.Queries;
using Application.Repositories;
using Domain.DownloadableItems;

namespace Application.QueryHandlers;

public class
    GetNotFinalizedQueryHandler(IDownloadableItemsRepository repository)
    : IQueryHandler<GetNotFinalizedItemsQuery, IEnumerable<DownloadableItem>>
{
    public async Task<IEnumerable<DownloadableItem>> Handle(GetNotFinalizedItemsQuery query)
    {
        var items = await repository.GetAll();
        return items;
    }
}