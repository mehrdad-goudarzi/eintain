using Application.Commands;
using Application.Repositories;
using Domain.DownloadableItems;

namespace Application.CommandHandlers;

public class InitiateDownloadHandler(IDownloadableItemsRepository repository) : ICommandHandler<InitiateDownloadCommand>
{
    public async Task Handle(InitiateDownloadCommand command)
    {
        var item = DownloadableItem.Initiate(command.Uri);
        await repository.Persist(item.Id.ToString(), item.Events);
    }
}