namespace Application.Commands;

public record FinishDownloadCommand(Guid Id, string Path) : ICommand;