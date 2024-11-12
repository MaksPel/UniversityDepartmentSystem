using Microsoft.AspNetCore.Mvc;
﻿using MediatR;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Application.Requests.Queries;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Web.Controllers;

[Route("api/teachers")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeacherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var teachers = await _mediator.Send(new GetTeachersQuery());

        return Ok(teachers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var teacher = await _mediator.Send(new GetTeacherByIdQuery(id));

        if (teacher is null)
        {
            return NotFound($"Teacher with id {id} is not found.");
        }
        
        return Ok(teacher);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TeacherForCreationDto? teacher)
    {
        if (teacher is null)
        {
            return BadRequest("Object for creation is null");
        }

        await _mediator.Send(new CreateTeacherCommand(teacher));

        return CreatedAtAction(nameof(Create), teacher);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] TeacherForUpdateDto? teacher)
    {
        if (teacher is null)
        {
            return BadRequest("Object for update is null");
        }

        var isEntityFound = await _mediator.Send(new UpdateTeacherCommand(teacher));

        if (!isEntityFound)
        {
            return NotFound($"Teacher with id {id} is not found.");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var isEntityFound = await _mediator.Send(new DeleteTeacherCommand(id));

        if (!isEntityFound)
        {
            return NotFound($"Teacher with id {id} is not found.");
        }

        return NoContent();
    }
}
