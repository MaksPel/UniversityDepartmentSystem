using Microsoft.AspNetCore.Mvc;
﻿using MediatR;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Application.Requests.Queries;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.WebMVC.Controllers;

public class SpecialitiesController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ResponseCache(Duration = 290, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<IActionResult> Index()
    {
        var specialties = await _mediator.Send(new GetSpecialtiesQuery());

        return View(specialties);
    }

    [HttpGet]
    [ResponseCache(Duration = 290, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<IActionResult> Details(Guid id)
    {
        var specialty = await _mediator.Send(new GetSpecialtyByIdQuery(id));

        if (specialty is null)
        {
            return NotFound($"Specialty with id {id} is not found.");
        }
        
        return View(specialty);
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

    [HttpPut]
    public async Task<IActionResult> Edit(Guid id, [FromBody] SpecialtyForUpdateDto? specialty)
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

    [HttpDelete]
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
