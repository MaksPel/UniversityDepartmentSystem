using Microsoft.AspNetCore.Mvc;
﻿using MediatR;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Application.Requests.Queries;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.WebMVC.Controllers;

public class FacultiesController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ResponseCache(Duration = 290, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<IActionResult> Index()
    {
        var faculties = await _mediator.Send(new GetFacultiesQuery());

        return View(faculties);
    }

    [HttpGet]
    [ResponseCache(Duration = 290, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<IActionResult> Details(Guid id)
    {
        var faculty = await _mediator.Send(new GetFacultyByIdQuery(id));

        if (faculty is null)
        {
            return NotFound($"Faculty with id {id} is not found.");
        }
        
        return View(faculty);
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

    [HttpPut]
    public async Task<IActionResult> Edit(Guid id, [FromBody] FacultyForUpdateDto? faculty)
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

    [HttpDelete]
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
