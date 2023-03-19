using DataAccess.Models.Responses;
using EventsAPI.Controllers;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Text.Json;
using DataAccess.Models;

namespace EventsTests;

[TestFixture]
public class EventsControllerTests
{
    private EventsController _controller;
    private Mock<IEventsService> _eventsServiceMock;
    private Mock<IVenuesService> _venuesServiceMock;
    private Mock<ICollectionsService> _collectionsServiceMock;
    private Mock<ICategoriesService> _categoriesServiceMock;

    [SetUp]
    public void Setup()
    {
        _eventsServiceMock = new Mock<IEventsService>();
        _venuesServiceMock = new Mock<IVenuesService>();
        _collectionsServiceMock = new Mock<ICollectionsService>();
        _categoriesServiceMock = new Mock<ICategoriesService>();
        _controller = new EventsController(_eventsServiceMock.Object, _venuesServiceMock.Object, _collectionsServiceMock.Object, _categoriesServiceMock.Object);
    }

    private static HttpContext CreateMockHttpContext() =>
        new DefaultHttpContext
        {
            // RequestServices needs to be set so the IResult implementation can log.
            RequestServices = new ServiceCollection().AddLogging().BuildServiceProvider(),
            Response =
            {
                // The default response body is Stream.Null which throws away anything that is written to it.
                Body = new MemoryStream(),
            },
        };

    [Test]
    public async Task GetEvents_ReturnsOkResult()
    {
        // Arrange
        var mockHttpContext = CreateMockHttpContext();

        var events = new List<GetEventsResponse>()
        {
            new() { EventId = 1, CategoryId = 1, EventDateTime = new DateTimeOffset(), EventDescription = "Test", EventTitle = "Test1", VenueId = 1},
            new() { EventId = 2, CategoryId = 1, EventDateTime = new DateTimeOffset(), EventDescription = "Test", EventTitle = "Test2", VenueId = 1},
            new() { EventId = 3, CategoryId = 1, EventDateTime = new DateTimeOffset(), EventDescription = "Test", EventTitle = "Test3", VenueId = 1}
        };

        _eventsServiceMock.Setup(x => x.GetEvents()).ReturnsAsync(events);

        // Act
        var result = await _controller.GetEvents();

        // Assert
        Assert.IsInstanceOf<IResult>(result);

        await result.ExecuteAsync(mockHttpContext);

        // Reset MemoryStream to start so we can read the response.
        mockHttpContext.Response.Body.Position = 0;
        var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        var responseEvents = await JsonSerializer.DeserializeAsync<List<GetEventsResponse>>(mockHttpContext.Response.Body, jsonOptions);

        Assert.AreEqual(200, mockHttpContext.Response.StatusCode);
        Assert.AreEqual("Test1", responseEvents.First().EventTitle);
        Assert.AreEqual("Test3", responseEvents.Last().EventTitle);
    }

    [Test]
    public async Task GetEventById_ReturnsOkResult()
    {
        // Arrange
        var mockHttpContext = CreateMockHttpContext();
        
        var eventModel = new EventModel() { EventId = 1, CategoryId = 1, EventDateTime = new DateTimeOffset(), EventDescription = "Test", EventTitle = "Test1", VenueId = 1};

        _eventsServiceMock.Setup(x => x.GetEventById(1)).ReturnsAsync(eventModel);

        // Act
        var result = await _controller.GetEvents();

        // Assert
        Assert.IsInstanceOf<IResult>(result);

        await result.ExecuteAsync(mockHttpContext);

        // Reset MemoryStream to start so we can read the response.
        mockHttpContext.Response.Body.Position = 0;
        Assert.AreEqual(200, mockHttpContext.Response.StatusCode);
    }

    [Test]
    public async Task InsertEvent_ReturnsOkResult()
    {
        // Arrange
        var mockHttpContext = CreateMockHttpContext();

        var eventRequest = new EventModel() { EventId = 1, CategoryId = 1, EventDateTime = new DateTimeOffset(), EventDescription = "Test", EventTitle = "Test1", VenueId = 1 };

        // Act
        var result = await _controller.InsertEvent(eventRequest);

        // Assert
        Assert.IsInstanceOf<IResult>(result);

        await result.ExecuteAsync(mockHttpContext);

        // Reset MemoryStream to start so we can read the response.
        mockHttpContext.Response.Body.Position = 0;

        Assert.AreEqual(200, mockHttpContext.Response.StatusCode);
    }

    [Test]
    public async Task UpdateEvent_ReturnsOkResult()
    {
        // Arrange
        var mockHttpContext = CreateMockHttpContext();

        var eventRequest = new EventModel() { EventId = 1, CategoryId = 1, EventDateTime = new DateTimeOffset(), EventDescription = "Test", EventTitle = "Test1", VenueId = 1 };

        // Act
        var result = await _controller.UpdateEvent(eventRequest);

        // Assert
        Assert.IsInstanceOf<IResult>(result);

        await result.ExecuteAsync(mockHttpContext);

        // Reset MemoryStream to start so we can read the response.
        mockHttpContext.Response.Body.Position = 0;

        Assert.AreEqual(200, mockHttpContext.Response.StatusCode);
    }

    [Test]
    public async Task DeleteEvent_ReturnsOkResult()
    {
        // Arrange
        var mockHttpContext = CreateMockHttpContext();

        var eventIdRequest = 1;

        // Act
        var result = await _controller.DeleteEvent(eventIdRequest);

        // Assert
        Assert.IsInstanceOf<IResult>(result);

        await result.ExecuteAsync(mockHttpContext);

        // Reset MemoryStream to start so we can read the response.
        mockHttpContext.Response.Body.Position = 0;

        Assert.AreEqual(200, mockHttpContext.Response.StatusCode);
    }
}
