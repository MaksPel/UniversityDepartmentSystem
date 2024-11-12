using Microsoft.AspNetCore.Mvc;
﻿using MediatR;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Application.Requests.Queries;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Web.Controllers;

[Route("api/courses")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var courses = await _mediator.Send(new GetCoursesQuery());

        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var course = await _mediator.Send(new GetCourseByIdQuery(id));

        if (course is null)
        {
            return NotFound($"Course with id {id} is not found.");
        }
        
        return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CourseForCreationDto? course)
    {
        if (course is null)
        {
            return BadRequest("Object for creation is null");
        }

        await _mediator.Send(new CreateCourseCommand(course));

        return CreatedAtAction(nameof(Create), course);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CourseForUpdateDto? course)
    {
        if (course is null)
        {
            return BadRequest("Object for update is null");
        }

        var isEntityFound = await _mediator.Send(new UpdateCourseCommand(course));

        if (!isEntityFound)
        {
            return NotFound($"Course with id {id} is not found.");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var isEntityFound = await _mediator.Send(new DeleteCourseCommand(id));

        if (!isEntityFound)
        {
            return NotFound($"Course with id {id} is not found.");
        }

        return NoContent();
    }
}
