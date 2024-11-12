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

public class TeacherControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly TeacherController _controller;

    public TeacherControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new TeacherController(_mediatorMock.Object);
    }

    [Fact]
    public async Task Get_ReturnsListOfTeachers()
    {
        // Arrange
        var teachers = new List<TeacherDto> { new(), new() };

        _mediatorMock
            .Setup(m => m.Send(new GetTeachersQuery(), CancellationToken.None))
            .ReturnsAsync(teachers);

        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));

        var okResult = result as OkObjectResult;
        okResult?.StatusCode.Should().Be((int)HttpStatusCode.OK);

        var value = okResult?.Value as List<TeacherDto>;
        value.Should().HaveCount(2);
        value.Should().BeEquivalentTo(teachers);

        _mediatorMock.Verify(m => m.Send(new GetTeachersQuery(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GetById_ExistingTeacherId_ReturnsTeacher()
    {
        // Arrange
        var teacherId = Guid.NewGuid();
        var teacher = new TeacherDto { Id = teacherId };

        _mediatorMock
            .Setup(m => m.Send(new GetTeacherByIdQuery(teacherId), CancellationToken.None))
            .ReturnsAsync(teacher);

        // Act
        var result = await _controller.GetById(teacherId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));

        var okResult = result as OkObjectResult;
        okResult?.StatusCode.Should().Be((int)HttpStatusCode.OK);
        (okResult?.Value as TeacherDto).Should().BeEquivalentTo(teacher);

        _mediatorMock.Verify(m => m.Send(new GetTeacherByIdQuery(teacherId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GetById_NotExistingTeacherId_ReturnsNotFoundResult()
    {
        // Arrange
        var teacherId = Guid.NewGuid();
        var teacher = new TeacherDto { Id = teacherId };

        _mediatorMock
            .Setup(m => m.Send(new GetTeacherByIdQuery(teacherId), CancellationToken.None))
            .ReturnsAsync((TeacherDto?)null);

        // Act
        var result = await _controller.GetById(teacherId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new GetTeacherByIdQuery(teacherId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Create_Teacher_ReturnsTeacher()
    {
        // Arrange
        var teacher = new TeacherForCreationDto();

        _mediatorMock.Setup(m => m.Send(new CreateTeacherCommand(teacher), CancellationToken.None));

        // Act
        var result = await _controller.Create(teacher);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(CreatedAtActionResult));

        var createdResult = result as CreatedAtActionResult;
        createdResult?.StatusCode.Should().Be((int)HttpStatusCode.Created);
        (createdResult?.Value as TeacherForCreationDto).Should().BeEquivalentTo(teacher);

        _mediatorMock.Verify(m => m.Send(new CreateTeacherCommand(teacher), CancellationToken.None), Times.Once);
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

        _mediatorMock.Verify(m => m.Send(new CreateTeacherCommand(It.IsAny<TeacherForCreationDto>()), CancellationToken.None), Times.Never);
    }

    [Fact]
    public async Task Update_ExistingTeacher_ReturnsNoContentResult()
    {
        // Arrange
        var teacherId = Guid.NewGuid();
        var teacher = new TeacherForUpdateDto { Id = teacherId };

        _mediatorMock
            .Setup(m => m.Send(new UpdateTeacherCommand(teacher), CancellationToken.None))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Update(teacherId, teacher);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NoContentResult));
        (result as NoContentResult)?.StatusCode.Should().Be((int)HttpStatusCode.NoContent);

        _mediatorMock.Verify(m => m.Send(new UpdateTeacherCommand(teacher), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Update_NotExistingTeacher_ReturnsNotFoundResult()
    {
        // Arrange
        var teacherId = Guid.NewGuid();
        var teacher = new TeacherForUpdateDto { Id = teacherId };

        _mediatorMock
            .Setup(m => m.Send(new UpdateTeacherCommand(teacher), CancellationToken.None))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.Update(teacherId, teacher);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new UpdateTeacherCommand(teacher), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Update_NullValue_ReturnsBadRequest()
    {
        // Arrange
        var teacherId = Guid.NewGuid();

        // Act
        var result = await _controller.Update(teacherId, null);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(BadRequestObjectResult));
        (result as BadRequestObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);

        _mediatorMock.Verify(m => m.Send(new UpdateTeacherCommand(It.IsAny<TeacherForUpdateDto>()), CancellationToken.None), Times.Never);
    }

    [Fact]
    public async Task Delete_ExistingTeacherId_ReturnsNoContentResult()
    {
        // Arrange
        var teacherId = Guid.NewGuid();

        _mediatorMock
            .Setup(m => m.Send(new DeleteTeacherCommand(teacherId), CancellationToken.None))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(teacherId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NoContentResult));
        (result as NoContentResult)?.StatusCode.Should().Be((int)HttpStatusCode.NoContent);

        _mediatorMock.Verify(m => m.Send(new DeleteTeacherCommand(teacherId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Delete_NotExistingTeacherId_ReturnsNotFoundResult()
    {
        // Arrange
        var teacherId = Guid.NewGuid();

        _mediatorMock
            .Setup(m => m.Send(new DeleteTeacherCommand(teacherId), CancellationToken.None))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.Delete(teacherId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new DeleteTeacherCommand(teacherId), CancellationToken.None), Times.Once);
    }
}

