using Application.CommandHandlers;
using Application.Repositories;
using Domain.DownloadableItems;
using Domain.DownloadableItems.Events;
using Moq;

namespace Application.Tests;

public class FinishDownloadCommand
{
    [Fact]
    public async Task ItPersistsTheFinishedState()
    {
        //Arrange
        var repo = new Mock<IDownloadableItemsRepository>();
        var item = DownloadableItem.Initiate(new Uri("http://localhost:8080/"));
        var command = new Application.Commands.FinishDownloadCommand(item.Id, "c://");
        repo.Setup(x => x.Load(command.Id.ToString())).ReturnsAsync(item);
        var handler = new FinishDownloadHandler(repo.Object);

        //Act
        await handler.Handle(command);

        //Assert
        repo.Verify(
            x => x.Persist(It.IsAny<string>(),
                It.Is<IReadOnlyCollection<IDomainEvent>>(z =>
                    z.Any(c => (c.GetType() == typeof(DownloadableItemFinishedSuccessfully)) &&
                               ((DownloadableItemFinishedSuccessfully)c).Path == command.Path))),
            Times.Once);
    }
}