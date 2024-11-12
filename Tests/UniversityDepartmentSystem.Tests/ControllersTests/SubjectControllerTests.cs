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

public class SubjectControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly SubjectController _controller;

    public SubjectControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new SubjectController(_mediatorMock.Object);
    }

    [Fact]
    public async Task Get_ReturnsListOfSubjects()
    {
        // Arrange
        var subjects = new List<SubjectDto> { new(), new() };

        _mediatorMock
            .Setup(m => m.Send(new GetSubjectsQuery(), CancellationToken.None))
            .ReturnsAsync(subjects);

        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));

        var okResult = result as OkObjectResult;
        okResult?.StatusCode.Should().Be((int)HttpStatusCode.OK);

        var value = okResult?.Value as List<SubjectDto>;
        value.Should().HaveCount(2);
        value.Should().BeEquivalentTo(subjects);

        _mediatorMock.Verify(m => m.Send(new GetSubjectsQuery(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GetById_ExistingSubjectId_ReturnsSubject()
    {
        // Arrange
        var subjectId = Guid.NewGuid();
        var subject = new SubjectDto { Id = subjectId };

        _mediatorMock
            .Setup(m => m.Send(new GetSubjectByIdQuery(subjectId), CancellationToken.None))
            .ReturnsAsync(subject);

        // Act
        var result = await _controller.GetById(subjectId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));

        var okResult = result as OkObjectResult;
        okResult?.StatusCode.Should().Be((int)HttpStatusCode.OK);
        (okResult?.Value as SubjectDto).Should().BeEquivalentTo(subject);

        _mediatorMock.Verify(m => m.Send(new GetSubjectByIdQuery(subjectId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GetById_NotExistingSubjectId_ReturnsNotFoundResult()
    {
        // Arrange
        var subjectId = Guid.NewGuid();
        var subject = new SubjectDto { Id = subjectId };

        _mediatorMock
            .Setup(m => m.Send(new GetSubjectByIdQuery(subjectId), CancellationToken.None))
            .ReturnsAsync((SubjectDto?)null);

        // Act
        var result = await _controller.GetById(subjectId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new GetSubjectByIdQuery(subjectId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Create_Subject_ReturnsSubject()
    {
        // Arrange
        var subject = new SubjectForCreationDto();

        _mediatorMock.Setup(m => m.Send(new CreateSubjectCommand(subject), CancellationToken.None));

        // Act
        var result = await _controller.Create(subject);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(CreatedAtActionResult));

        var createdResult = result as CreatedAtActionResult;
        createdResult?.StatusCode.Should().Be((int)HttpStatusCode.Created);
        (createdResult?.Value as SubjectForCreationDto).Should().BeEquivalentTo(subject);

        _mediatorMock.Verify(m => m.Send(new CreateSubjectCommand(subject), CancellationToken.None), Times.Once);
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

        _mediatorMock.Verify(m => m.Send(new CreateSubjectCommand(It.IsAny<SubjectForCreationDto>()), CancellationToken.None), Times.Never);
    }

    [Fact]
    public async Task Update_ExistingSubject_ReturnsNoContentResult()
    {
        // Arrange
        var subjectId = Guid.NewGuid();
        var subject = new SubjectForUpdateDto { Id = subjectId };

        _mediatorMock
            .Setup(m => m.Send(new UpdateSubjectCommand(subject), CancellationToken.None))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Update(subjectId, subject);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NoContentResult));
        (result as NoContentResult)?.StatusCode.Should().Be((int)HttpStatusCode.NoContent);

        _mediatorMock.Verify(m => m.Send(new UpdateSubjectCommand(subject), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Update_NotExistingSubject_ReturnsNotFoundResult()
    {
        // Arrange
        var subjectId = Guid.NewGuid();
        var subject = new SubjectForUpdateDto { Id = subjectId };

        _mediatorMock
            .Setup(m => m.Send(new UpdateSubjectCommand(subject), CancellationToken.None))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.Update(subjectId, subject);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new UpdateSubjectCommand(subject), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Update_NullValue_ReturnsBadRequest()
    {
        // Arrange
        var subjectId = Guid.NewGuid();

        // Act
        var result = await _controller.Update(subjectId, null);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(BadRequestObjectResult));
        (result as BadRequestObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);

        _mediatorMock.Verify(m => m.Send(new UpdateSubjectCommand(It.IsAny<SubjectForUpdateDto>()), CancellationToken.None), Times.Never);
    }

    [Fact]
    public async Task Delete_ExistingSubjectId_ReturnsNoContentResult()
    {
        // Arrange
        var subjectId = Guid.NewGuid();

        _mediatorMock
            .Setup(m => m.Send(new DeleteSubjectCommand(subjectId), CancellationToken.None))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(subjectId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NoContentResult));
        (result as NoContentResult)?.StatusCode.Should().Be((int)HttpStatusCode.NoContent);

        _mediatorMock.Verify(m => m.Send(new DeleteSubjectCommand(subjectId), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Delete_NotExistingSubjectId_ReturnsNotFoundResult()
    {
        // Arrange
        var subjectId = Guid.NewGuid();

        _mediatorMock
            .Setup(m => m.Send(new DeleteSubjectCommand(subjectId), CancellationToken.None))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.Delete(subjectId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult)?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        _mediatorMock.Verify(m => m.Send(new DeleteSubjectCommand(subjectId), CancellationToken.None), Times.Once);
    }
}

