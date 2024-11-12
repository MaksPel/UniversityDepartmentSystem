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

public class FacultyControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly FacultyController _controller;

    public FacultyControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new FacultyController(_mediatorMock.Object);
    }

    [Fact]
    public async Task Get_ReturnsListOfFaculties()
    {
        // Arrange
        var faculties = new List<FacultyDto> { new(), new() };

        _mediatorMock
            .Setup(m => m.Send(new GetFacultiesQuery(), CancellationToken.None))
            .ReturnsAsync(faculties);

        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));

        var okResult = result as OkObjectResult;
        okResult?.StatusCode.Should().Be((int)HttpStatusCode.OK);

        var value = okResult?.Value as List<FacultyDto>;
        value.Should().HaveCount(2);
        value.Should().BeEquivalentTo(faculties);

        _mediatorMock.Verify(m => m.Send(new GetFacultiesQuery(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GetById_ExistingFacultyId_ReturnsFaculty()
    {
        // Arrange
        var facultyId = Guid.NewGuid();
        var faculty = new FacultyDto { Id = facultyId };

        _mediatorMock
            .Setup(m => m.Send(new GetFacultyByIdQuery(facultyId), CancellationToken.None))
            .ReturnsAsync(faculty);

        // Act
        var result = await _controller.GetById(facultyId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));

        var okResult = result as OkObjectResult;
        okResult?.StatusCode.Should().Be((int)HttpStatusCode.OK);
        (okResult?.Value as FacultyDto).Should().BeEquivalentTo(faculty);

        _mediatorMock.Verify(m => m.Send(new GetFacultyByIdQuery(facultyId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GetById_NotExistingFacultyId_ReturnsNotFoundResult()
    {
        // Arrange
        var facultyId = Guid.NewGuid();
        var faculty = new FacultyDto { Id = facultyId };

        _mediatorMock
            .Setup(m => m.Send(new GetFacultyByIdQuery(facultyId), CancellationToken.None))
            .ReturnsAsync((FacultyDto?)null);

        // Act
        var result = await _controller.GetById(facultyId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new GetFacultyByIdQuery(facultyId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Create_Faculty_ReturnsFaculty()
    {
        // Arrange
        var faculty = new FacultyForCreationDto();

        _mediatorMock.Setup(m => m.Send(new CreateFacultyCommand(faculty), CancellationToken.None));

        // Act
        var result = await _controller.Create(faculty);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(CreatedAtActionResult));

        var createdResult = result as CreatedAtActionResult;
        createdResult?.StatusCode.Should().Be((int)HttpStatusCode.Created);
        (createdResult?.Value as FacultyForCreationDto).Should().BeEquivalentTo(faculty);

        _mediatorMock.Verify(m => m.Send(new CreateFacultyCommand(faculty), CancellationToken.None), Times.Once);
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

        _mediatorMock.Verify(m => m.Send(new CreateFacultyCommand(It.IsAny<FacultyForCreationDto>()), CancellationToken.None), Times.Never);
    }

    [Fact]
    public async Task Update_ExistingFaculty_ReturnsNoContentResult()
    {
        // Arrange
        var facultyId = Guid.NewGuid();
        var faculty = new FacultyForUpdateDto { Id = facultyId };

        _mediatorMock
            .Setup(m => m.Send(new UpdateFacultyCommand(faculty), CancellationToken.None))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Update(facultyId, faculty);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NoContentResult));
        (result as NoContentResult)?.StatusCode.Should().Be((int)HttpStatusCode.NoContent);

        _mediatorMock.Verify(m => m.Send(new UpdateFacultyCommand(faculty), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Update_NotExistingFaculty_ReturnsNotFoundResult()
    {
        // Arrange
        var facultyId = Guid.NewGuid();
        var faculty = new FacultyForUpdateDto { Id = facultyId };

        _mediatorMock
            .Setup(m => m.Send(new UpdateFacultyCommand(faculty), CancellationToken.None))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.Update(facultyId, faculty);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new UpdateFacultyCommand(faculty), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Update_NullValue_ReturnsBadRequest()
    {
        // Arrange
        var facultyId = Guid.NewGuid();

        // Act
        var result = await _controller.Update(facultyId, null);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(BadRequestObjectResult));
        (result as BadRequestObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);

        _mediatorMock.Verify(m => m.Send(new UpdateFacultyCommand(It.IsAny<FacultyForUpdateDto>()), CancellationToken.None), Times.Never);
    }

    [Fact]
    public async Task Delete_ExistingFacultyId_ReturnsNoContentResult()
    {
        // Arrange
        var facultyId = Guid.NewGuid();

        _mediatorMock
            .Setup(m => m.Send(new DeleteFacultyCommand(facultyId), CancellationToken.None))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(facultyId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NoContentResult));
        (result as NoContentResult)?.StatusCode.Should().Be((int)HttpStatusCode.NoContent);

        _mediatorMock.Verify(m => m.Send(new DeleteFacultyCommand(facultyId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Delete_NotExistingFacultyId_ReturnsNotFoundResult()
    {
        // Arrange
        var facultyId = Guid.NewGuid();

        _mediatorMock
            .Setup(m => m.Send(new DeleteFacultyCommand(facultyId), CancellationToken.None))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.Delete(facultyId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new DeleteFacultyCommand(facultyId), CancellationToken.None), Times.Once);
    }
}

