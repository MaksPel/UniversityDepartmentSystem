using Microsoft.AspNetCore.Mvc;
﻿using MediatR;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Application.Requests.Queries;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Web.Controllers;

[Route("api/faculties")]
[ApiController]
public class FacultyController : ControllerBase
{
    private readonly IMediator _mediator;

    public FacultyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var faculties = await _mediator.Send(new GetFacultiesQuery());

        return Ok(faculties);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var faculty = await _mediator.Send(new GetFacultyByIdQuery(id));

        if (faculty is null)
        {
            return NotFound($"Faculty with id {id} is not found.");
        }
        
        return Ok(faculty);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FacultyForCreationDto? faculty)
    {
        if (faculty is null)
        {
            return BadRequest("Object for creation is null");
        }

        await _mediator.Send(new CreateFacultyCommand(faculty));

        return CreatedAtAction(nameof(Create), faculty);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] FacultyForUpdateDto? faculty)
    {
        if (faculty is null)
        {
            return BadRequest("Object for update is null");
        }

        var isEntityFound = await _mediator.Send(new UpdateFacultyCommand(faculty));

        if (!isEntityFound)
        {
            return NotFound($"Faculty with id {id} is not found.");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var isEntityFound = await _mediator.Send(new DeleteFacultyCommand(id));

        if (!isEntityFound)
        {
            return NotFound($"Faculty with id {id} is not found.");
        }

        return NoContent();
    }
}
