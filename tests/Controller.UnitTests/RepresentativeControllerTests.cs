using Application.Features.Representatives.Abstractions;
using Application.Features.Representatives.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;

namespace Controller.UnitTests;

public class RepresentativeControllerTests
{
    [Fact]
    public async Task Given_A_Service_NoError_Response_When_Querying_Reps_Returns_Ok()
    {
        // Arrange
        var repList = new List<RepresentativeDto>();
        var mockService = new Mock<IRepresentativeService>(MockBehavior.Strict);
        mockService.Setup(s => s.GetAll()).ReturnsAsync(repList);
        var sut = new RepresentativeController(mockService.Object);

        // Act
        var response = await sut.GetAll();

        // Assert
        response.Should().BeOfType<ActionResult<List<RepresentativeDto>>>();
        response.Result.Should().BeOfType<OkObjectResult>();

    }

    [Fact]
    public async Task Given_A_Service_Error_Response_When_Querying_Reps_Returns_Problem()
    {
        // Arrange
        var mockService = new Mock<IRepresentativeService>(MockBehavior.Strict);
        mockService.Setup(s => s.GetAll()).ThrowsAsync(new Exception());
        var sut = new RepresentativeController(mockService.Object);

        // Act
        var response = await sut.GetAll();

        // Assert
        response.Should().BeOfType<ActionResult<List<RepresentativeDto>>>();
        var convertedResponse = (ObjectResult)response.Result;
        convertedResponse.StatusCode.Should().Be(500);

    }

    [Fact]
    public async Task Given_A_Service_NoError_Response_When_Adding_A_Rep_Returns_Ok()
    {
        // Arrange
        var newRepresentativeDto = new RepresentativeDto { Name = "Sample Name" };
        var mockService = new Mock<IRepresentativeService>(MockBehavior.Strict);
        mockService.Setup(s => s.Add(It.IsAny<RepresentativeDto>())).ReturnsAsync(newRepresentativeDto);
        var sut = new RepresentativeController(mockService.Object);

        // Act
        var response = await sut.Add(newRepresentativeDto);

        // Assert
        response.Should().BeOfType<ActionResult<RepresentativeDto>>();
        response.Result.Should().BeOfType<OkObjectResult>();

    }

    [Fact]
    public async Task Given_A_Service_Error_Response_When_Adding_A_Rep_Returns_Problem()
    {
        // Arrange
        var newRepresentativeDto = new RepresentativeDto { Name = "Sample Name" };
        var mockService = new Mock<IRepresentativeService>(MockBehavior.Strict);
        mockService.Setup(s => s.Add(It.IsAny<RepresentativeDto>())).ThrowsAsync(new Exception());
        var sut = new RepresentativeController(mockService.Object);

        // Act
        var response = await sut.Add(newRepresentativeDto);

        // Assert
        response.Should().BeOfType<ActionResult<RepresentativeDto>>();
        var convertedResponse = (ObjectResult)response.Result;
        convertedResponse.StatusCode.Should().Be(500);

    }

    [Fact]
    public async Task Given_A_Service_NoError_Response_When_Modifying_A_Rep_Returns_Ok()
    {
        // Arrange
        var newRepresentativeDto = new RepresentativeDto { Name = "Sample Name" };
        var mockService = new Mock<IRepresentativeService>(MockBehavior.Strict);
        mockService.Setup(s => s.Update(It.IsAny<RepresentativeDto>())).ReturnsAsync(newRepresentativeDto);
        var sut = new RepresentativeController(mockService.Object);

        // Act
        var response = await sut.Update(newRepresentativeDto);

        // Assert
        response.Should().BeOfType<ActionResult<RepresentativeDto>>();
        response.Result.Should().BeOfType<OkObjectResult>();

    }

    [Fact]
    public async Task Given_A_Service_Error_Response_When_Modifying_A_Rep_Returns_Problem()
    {
        // Arrange
        var newRepresentativeDto = new RepresentativeDto { Name = "Sample Name" };
        var mockService = new Mock<IRepresentativeService>(MockBehavior.Strict);
        mockService.Setup(s => s.Update(It.IsAny<RepresentativeDto>())).ThrowsAsync(new Exception());
        var sut = new RepresentativeController(mockService.Object);

        // Act
        var response = await sut.Update(newRepresentativeDto);

        // Assert
        response.Should().BeOfType<ActionResult<RepresentativeDto>>();
        var convertedResponse = (ObjectResult)response.Result;
        convertedResponse.StatusCode.Should().Be(500);

    }

    [Fact]
    public async Task Given_A_Service_NoError_Response_When_Removing_A_Rep_Returns_No_Content()
    {
        // Arrange
        var mockService = new Mock<IRepresentativeService>(MockBehavior.Strict);
        mockService.Setup(s => s.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
        var sut = new RepresentativeController(mockService.Object);

        // Act
        var response = await sut.Delete(1);

        // Assert
        response.Should().BeOfType<NoContentResult>();

    }

    [Fact]
    public async Task Given_A_Service_Error_Response_When_Removing_A_Rep_Returns_Problem()
    {
        // Arrange
        var mockService = new Mock<IRepresentativeService>(MockBehavior.Strict);
        mockService.Setup(s => s.Delete(It.IsAny<int>())).Throws(new Exception());
        var sut = new RepresentativeController(mockService.Object);

        // Act
        var response = await sut.Delete(1);

        // Assert
        response.Should().BeOfType<ObjectResult>();
        var convertedResponse = (ObjectResult)response;
        convertedResponse.StatusCode.Should().Be(500);

    }
}