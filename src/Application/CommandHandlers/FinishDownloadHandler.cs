using Application.Commands;
using Application.Repositories;

namespace Application.CommandHandlers;

public class FinishDownloadHandler(IDownloadableItemsRepository repository) : ICommandHandler<FinishDownloadCommand>
{
    public async Task Handle(FinishDownloadCommand command)
    {
        var item = await repository.Load(command.Id.ToString());
        item.FinishedSuccessfully(command.Path);
        await repository.Persist(command.Id.ToString(), item.Events);
    }
}