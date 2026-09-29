using Application.CommandHandlers;
using Application.Queries;
using Application.QueryHandlers;
using Domain.DownloadableItems;
using Microsoft.Extensions.Options;
using Moq;

namespace Application.Tests;

public class DownloadScheduler
{
    [Fact]
    public async Task ItDownloadsTheItems()
    {
        //Arrange
        var config = new Mock<IOptions<AppConfigs>>();
        config.Setup(o => o.Value).Returns(new AppConfigs() { ParallelismLevel = 1, TotalCapacity = 10 });
        var handler = new Mock<ICommandHandler<Commands.FinishDownloadCommand>>();
        handler.Setup(x => x.Handle(It.IsAny<Commands.FinishDownloadCommand>())).Returns(Task.CompletedTask);
        var queryHandler = new Mock<IQueryHandler<GetNotFinalizedItemsQuery, IEnumerable<DownloadableItem>>>();
        queryHandler.Setup(x => x.Handle(It.IsAny<GetNotFinalizedItemsQuery>()))
            .ReturnsAsync(new List<DownloadableItem>() { DownloadableItem.Initiate(new Uri("https://google.com")) });
        var agent = new DownloadAgent(config.Object, handler.Object);
        var schedule = new Application.DownloadScheduler(queryHandler.Object, agent);

        //Act
        await schedule.Execute();

        //Assert
        handler.Verify(x=>x.Handle(It.IsAny<Commands.FinishDownloadCommand>()), Times.Once);
    }
}