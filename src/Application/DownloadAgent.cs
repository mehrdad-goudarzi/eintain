using System.Threading.Tasks.Dataflow;
using Application.CommandHandlers;
using Application.Commands;
using Domain.DownloadableItems;
using Microsoft.Extensions.Options;

namespace Application;

public class DownloadAgent
{
    private readonly ICommandHandler<FinishDownloadCommand> _commandHandler;
    private readonly ActionBlock<DownloadableItem> _block;

    public DownloadAgent(IOptions<AppConfigs> configs, ICommandHandler<FinishDownloadCommand> commandHandler)
    {
        _commandHandler = commandHandler;
        _block = new ActionBlock<DownloadableItem>(ProcessItem,
            new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = configs.Value.ParallelismLevel,
                BoundedCapacity = configs.Value.TotalCapacity
            });
    }

    public Task AppendToQueue(DownloadableItem item)
    {
        return _block.SendAsync(item);
    }

    public Task WaitUntilCompletion()
    {
        _block.Complete();
        return _block.Completion;
    }

    private async Task ProcessItem(DownloadableItem item)
    {
        // the download is taking place here:
        // and is saved at `c://`
        var command = new FinishDownloadCommand(item.Id, "c://");
        await _commandHandler.Handle(command);
    }
}