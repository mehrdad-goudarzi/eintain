using Application.CommandHandlers;
using Application.Repositories;
using Domain.DownloadableItems.Events;
using Moq;

namespace Application.Tests;

public class InitiateDownloadCommand
{
    [Fact]
    public async Task ItPersistsTheItem()
    {
        //Arrange
        var command = new Application.Commands.InitiateDownloadCommand(new Uri("https://www.google.com/"));
        var repo = new Mock<IDownloadableItemsRepository>();
        var handler = new InitiateDownloadHandler(repo.Object);

        //Act
        await handler.Handle(command);

        //Assert
        repo.Verify(
            x => x.Persist(It.IsAny<string>(),
                It.Is<IReadOnlyCollection<IDomainEvent>>(z =>
                    z.Any(c => (c.GetType() == typeof(DownloadableItemInitiated)) &&
                               ((DownloadableItemInitiated)c).Uri == command.Uri))),
            Times.Once);
    }
}