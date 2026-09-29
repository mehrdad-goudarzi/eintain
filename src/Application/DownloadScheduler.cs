using Application.Queries;
using Application.QueryHandlers;
using Domain.DownloadableItems;

namespace Application;

public class DownloadScheduler(IQueryHandler<GetNotFinalizedItemsQuery, IEnumerable<DownloadableItem>> queryHandler,
    DownloadAgent downloadAgent)
{
    public async Task Execute()
    {
        var query = new GetNotFinalizedItemsQuery();
        var items = await queryHandler.Handle(query);
        foreach (var item in items)
        {
            await downloadAgent.AppendToQueue(item);
        }
    }

    public Task WaitUntilCompletion()
    {
        return downloadAgent.WaitUntilCompletion();
    }
}