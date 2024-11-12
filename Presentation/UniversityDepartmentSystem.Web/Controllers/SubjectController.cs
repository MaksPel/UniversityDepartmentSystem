using Microsoft.AspNetCore.Mvc;
﻿using MediatR;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Application.Requests.Queries;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Web.Controllers;

[Route("api/subjects")]
[ApiController]
public class SubjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var subjects = await _mediator.Send(new GetSubjectsQuery());

        return Ok(subjects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var subject = await _mediator.Send(new GetSubjectByIdQuery(id));

        if (subject is null)
        {
            return NotFound($"Subject with id {id} is not found.");
        }
        
        return Ok(subject);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SubjectForCreationDto? subject)
    {
        if (subject is null)
        {
            return BadRequest("Object for creation is null");
        }

        await _mediator.Send(new CreateSubjectCommand(subject));

        return CreatedAtAction(nameof(Create), subject);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] SubjectForUpdateDto? subject)
    {
        if (subject is null)
        {
            return BadRequest("Object for update is null");
        }

        var isEntityFound = await _mediator.Send(new UpdateSubjectCommand(subject));

        if (!isEntityFound)
        {
            return NotFound($"Subject with id {id} is not found.");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var isEntityFound = await _mediator.Send(new DeleteSubjectCommand(id));

        if (!isEntityFound)
        {
            return NotFound($"Subject with id {id} is not found.");
        }

        return NoContent();
    }
}
