using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Application.Requests.Queries;
using UniversityDepartmentSystem.Application.Requests.Commands;
using UniversityDepartmentSystem.Web.Controllers;

namespace UniversityDepartmentSystem.Tests.ControllersTests;

public class SpecialtyControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly SpecialtyController _controller;

    public SpecialtyControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new SpecialtyController(_mediatorMock.Object);
    }

    [Fact]
    public async Task Get_ReturnsListOfSpecialties()
    {
        // Arrange
        var specialties = new List<SpecialtyDto> { new(), new() };

        _mediatorMock
            .Setup(m => m.Send(new GetSpecialtiesQuery(), CancellationToken.None))
            .ReturnsAsync(specialties);

        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));

        var okResult = result as OkObjectResult;
        okResult?.StatusCode.Should().Be((int)HttpStatusCode.OK);

        var value = okResult?.Value as List<SpecialtyDto>;
        value.Should().HaveCount(2);
        value.Should().BeEquivalentTo(specialties);

        _mediatorMock.Verify(m => m.Send(new GetSpecialtiesQuery(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GetById_ExistingSpecialtyId_ReturnsSpecialty()
    {
        // Arrange
        var specialtyId = Guid.NewGuid();
        var specialty = new SpecialtyDto { Id = specialtyId };

        _mediatorMock
            .Setup(m => m.Send(new GetSpecialtyByIdQuery(specialtyId), CancellationToken.None))
            .ReturnsAsync(specialty);

        // Act
        var result = await _controller.GetById(specialtyId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));

        var okResult = result as OkObjectResult;
        okResult?.StatusCode.Should().Be((int)HttpStatusCode.OK);
        (okResult?.Value as SpecialtyDto).Should().BeEquivalentTo(specialty);

        _mediatorMock.Verify(m => m.Send(new GetSpecialtyByIdQuery(specialtyId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GetById_NotExistingSpecialtyId_ReturnsNotFoundResult()
    {
        // Arrange
        var specialtyId = Guid.NewGuid();
        var specialty = new SpecialtyDto { Id = specialtyId };

        _mediatorMock
            .Setup(m => m.Send(new GetSpecialtyByIdQuery(specialtyId), CancellationToken.None))
            .ReturnsAsync((SpecialtyDto?)null);

        // Act
        var result = await _controller.GetById(specialtyId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new GetSpecialtyByIdQuery(specialtyId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Create_Specialty_ReturnsSpecialty()
    {
        // Arrange
        var specialty = new SpecialtyForCreationDto();

        _mediatorMock.Setup(m => m.Send(new CreateSpecialtyCommand(specialty), CancellationToken.None));

        // Act
        var result = await _controller.Create(specialty);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(CreatedAtActionResult));

        var createdResult = result as CreatedAtActionResult;
        createdResult?.StatusCode.Should().Be((int)HttpStatusCode.Created);
        (createdResult?.Value as SpecialtyForCreationDto).Should().BeEquivalentTo(specialty);

        _mediatorMock.Verify(m => m.Send(new CreateSpecialtyCommand(specialty), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Create_NullValue_ReturnsBadRequest()
    {
        // Arrange and Act
        var result = await _controller.Create(null);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(BadRequestObjectResult));
        (result as BadRequestObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);

        _mediatorMock.Verify(m => m.Send(new CreateSpecialtyCommand(It.IsAny<SpecialtyForCreationDto>()), CancellationToken.None), Times.Never);
    }

    [Fact]
    public async Task Update_ExistingSpecialty_ReturnsNoContentResult()
    {
        // Arrange
        var specialtyId = Guid.NewGuid();
        var specialty = new SpecialtyForUpdateDto { Id = specialtyId };

        _mediatorMock
            .Setup(m => m.Send(new UpdateSpecialtyCommand(specialty), CancellationToken.None))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Update(specialtyId, specialty);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NoContentResult));
        (result as NoContentResult)?.StatusCode.Should().Be((int)HttpStatusCode.NoContent);

        _mediatorMock.Verify(m => m.Send(new UpdateSpecialtyCommand(specialty), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Update_NotExistingSpecialty_ReturnsNotFoundResult()
    {
        // Arrange
        var specialtyId = Guid.NewGuid();
        var specialty = new SpecialtyForUpdateDto { Id = specialtyId };

        _mediatorMock
            .Setup(m => m.Send(new UpdateSpecialtyCommand(specialty), CancellationToken.None))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.Update(specialtyId, specialty);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new UpdateSpecialtyCommand(specialty), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Update_NullValue_ReturnsBadRequest()
    {
        // Arrange
        var specialtyId = Guid.NewGuid();

        // Act
        var result = await _controller.Update(specialtyId, null);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(BadRequestObjectResult));
        (result as BadRequestObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);

        _mediatorMock.Verify(m => m.Send(new UpdateSpecialtyCommand(It.IsAny<SpecialtyForUpdateDto>()), CancellationToken.None), Times.Never);
    }

    [Fact]
    public async Task Delete_ExistingSpecialtyId_ReturnsNoContentResult()
    {
        // Arrange
        var specialtyId = Guid.NewGuid();

        _mediatorMock
            .Setup(m => m.Send(new DeleteSpecialtyCommand(specialtyId), CancellationToken.None))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(specialtyId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NoContentResult));
        (result as NoContentResult)?.StatusCode.Should().Be((int)HttpStatusCode.NoContent);

        _mediatorMock.Verify(m => m.Send(new DeleteSpecialtyCommand(specialtyId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Delete_NotExistingSpecialtyId_ReturnsNotFoundResult()
    {
        // Arrange
        var specialtyId = Guid.NewGuid();

        _mediatorMock
            .Setup(m => m.Send(new DeleteSpecialtyCommand(specialtyId), CancellationToken.None))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.Delete(specialtyId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new DeleteSpecialtyCommand(specialtyId), CancellationToken.None), Times.Once);
    }
}

