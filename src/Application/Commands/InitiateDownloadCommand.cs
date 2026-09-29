namespace Application.Commands;

public record InitiateDownloadCommand(Uri Uri) : ICommand;