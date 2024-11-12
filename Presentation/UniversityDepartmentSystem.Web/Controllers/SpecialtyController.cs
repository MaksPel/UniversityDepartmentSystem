using Microsoft.AspNetCore.Mvc;
﻿using MediatR;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Application.Requests.Queries;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Web.Controllers;

[Route("api/specialties")]
[ApiController]
public class SpecialtyController : ControllerBase
{
    private readonly IMediator _mediator;

    public SpecialtyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var specialties = await _mediator.Send(new GetSpecialtiesQuery());

        return Ok(specialties);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var specialty = await _mediator.Send(new GetSpecialtyByIdQuery(id));

        if (specialty is null)
        {
            return NotFound($"Specialty with id {id} is not found.");
        }
        
        return Ok(specialty);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SpecialtyForCreationDto? specialty)
    {
        if (specialty is null)
        {
            return BadRequest("Object for creation is null");
        }

        await _mediator.Send(new CreateSpecialtyCommand(specialty));

        return CreatedAtAction(nameof(Create), specialty);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] SpecialtyForUpdateDto? specialty)
    {
        if (specialty is null)
        {
            return BadRequest("Object for update is null");
        }

        var isEntityFound = await _mediator.Send(new UpdateSpecialtyCommand(specialty));

        if (!isEntityFound)
        {
            return NotFound($"Specialty with id {id} is not found.");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var isEntityFound = await _mediator.Send(new DeleteSpecialtyCommand(id));

        if (!isEntityFound)
        {
            return NotFound($"Specialty with id {id} is not found.");
        }

        return NoContent();
    }
}
