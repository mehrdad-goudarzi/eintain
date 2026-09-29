using Domain.DownloadableItems.Events;
using FluentAssertions;

namespace Domain.Tests;

public class DownloadableItem
{
    [Fact]
    public void ItemInitiatedIsPublished()
    {
        //Act
        Uri uri = new Uri("https://www.google.com/");
        var id = Guid.NewGuid();
        var initiatedEvent = new DownloadableItemInitiated(id, uri);
        var downloadableItem = new DownloadableItems.DownloadableItem();
        downloadableItem.Evolve([initiatedEvent]);

        //Assert
        var expected = new DownloadableItemInitiated(downloadableItem.Id, uri);
        downloadableItem.Events.Should().ContainEquivalentOf(expected);
    }

    [Fact]
    public void ItemDownloadedIsPublished()
    {
        //Arrange
        Uri uri = new Uri("https://www.google.com/");
        string filePath = "./downloaded.html";
        var initiatedEvent = new DownloadableItemInitiated(Guid.NewGuid(), uri);
        var downloadableItem = new Domain.DownloadableItems.DownloadableItem();
        downloadableItem.Evolve([initiatedEvent]);
        var expected = new DownloadableItemFinishedSuccessfully(filePath);

        //Act
        downloadableItem.FinishedSuccessfully(filePath);

        //Assert
        downloadableItem.Events.Should().ContainEquivalentOf(expected);
    }
}