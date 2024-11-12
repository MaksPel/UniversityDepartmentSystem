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

public class CourseControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly CourseController _controller;

    public CourseControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new CourseController(_mediatorMock.Object);
    }

    [Fact]
    public async Task Get_ReturnsListOfCourses()
    {
        // Arrange
        var courses = new List<CourseDto> { new(), new() };

        _mediatorMock
            .Setup(m => m.Send(new GetCoursesQuery(), CancellationToken.None))
            .ReturnsAsync(courses);

        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));

        var okResult = result as OkObjectResult;
        okResult?.StatusCode.Should().Be((int)HttpStatusCode.OK);

        var value = okResult?.Value as List<CourseDto>;
        value.Should().HaveCount(2);
        value.Should().BeEquivalentTo(courses);

        _mediatorMock.Verify(m => m.Send(new GetCoursesQuery(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GetById_ExistingCourseId_ReturnsCourse()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var course = new CourseDto { Id = courseId };

        _mediatorMock
            .Setup(m => m.Send(new GetCourseByIdQuery(courseId), CancellationToken.None))
            .ReturnsAsync(course);

        // Act
        var result = await _controller.GetById(courseId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));

        var okResult = result as OkObjectResult;
        okResult?.StatusCode.Should().Be((int)HttpStatusCode.OK);
        (okResult?.Value as CourseDto).Should().BeEquivalentTo(course);

        _mediatorMock.Verify(m => m.Send(new GetCourseByIdQuery(courseId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GetById_NotExistingCourseId_ReturnsNotFoundResult()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var course = new CourseDto { Id = courseId };

        _mediatorMock
            .Setup(m => m.Send(new GetCourseByIdQuery(courseId), CancellationToken.None))
            .ReturnsAsync((CourseDto?)null);

        // Act
        var result = await _controller.GetById(courseId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new GetCourseByIdQuery(courseId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Create_Course_ReturnsCourse()
    {
        // Arrange
        var course = new CourseForCreationDto();

        _mediatorMock.Setup(m => m.Send(new CreateCourseCommand(course), CancellationToken.None));

        // Act
        var result = await _controller.Create(course);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(CreatedAtActionResult));

        var createdResult = result as CreatedAtActionResult;
        createdResult?.StatusCode.Should().Be((int)HttpStatusCode.Created);
        (createdResult?.Value as CourseForCreationDto).Should().BeEquivalentTo(course);

        _mediatorMock.Verify(m => m.Send(new CreateCourseCommand(course), CancellationToken.None), Times.Once);
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

        _mediatorMock.Verify(m => m.Send(new CreateCourseCommand(It.IsAny<CourseForCreationDto>()), CancellationToken.None), Times.Never);
    }

    [Fact]
    public async Task Update_ExistingCourse_ReturnsNoContentResult()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var course = new CourseForUpdateDto { Id = courseId };

        _mediatorMock
            .Setup(m => m.Send(new UpdateCourseCommand(course), CancellationToken.None))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Update(courseId, course);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NoContentResult));
        (result as NoContentResult)?.StatusCode.Should().Be((int)HttpStatusCode.NoContent);

        _mediatorMock.Verify(m => m.Send(new UpdateCourseCommand(course), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Update_NotExistingCourse_ReturnsNotFoundResult()
    {
        // Arrange
        var courseId = Guid.NewGuid();
        var course = new CourseForUpdateDto { Id = courseId };

        _mediatorMock
            .Setup(m => m.Send(new UpdateCourseCommand(course), CancellationToken.None))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.Update(courseId, course);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new UpdateCourseCommand(course), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Update_NullValue_ReturnsBadRequest()
    {
        // Arrange
        var courseId = Guid.NewGuid();

        // Act
        var result = await _controller.Update(courseId, null);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(BadRequestObjectResult));
        (result as BadRequestObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);

        _mediatorMock.Verify(m => m.Send(new UpdateCourseCommand(It.IsAny<CourseForUpdateDto>()), CancellationToken.None), Times.Never);
    }

    [Fact]
    public async Task Delete_ExistingCourseId_ReturnsNoContentResult()
    {
        // Arrange
        var courseId = Guid.NewGuid();

        _mediatorMock
            .Setup(m => m.Send(new DeleteCourseCommand(courseId), CancellationToken.None))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(courseId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NoContentResult));
        (result as NoContentResult)?.StatusCode.Should().Be((int)HttpStatusCode.NoContent);

        _mediatorMock.Verify(m => m.Send(new DeleteCourseCommand(courseId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Delete_NotExistingCourseId_ReturnsNotFoundResult()
    {
        // Arrange
        var courseId = Guid.NewGuid();

        _mediatorMock
            .Setup(m => m.Send(new DeleteCourseCommand(courseId), CancellationToken.None))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.Delete(courseId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new DeleteCourseCommand(courseId), CancellationToken.None), Times.Once);
    }
}

