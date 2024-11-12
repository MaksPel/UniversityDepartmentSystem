using Microsoft.AspNetCore.Mvc;
﻿using MediatR;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Application.Requests.Queries;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.WebMVC.Controllers;

public class TeachersController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ResponseCache(Duration = 290, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<IActionResult> Index()
    {
        var teachers = await _mediator.Send(new GetTeachersQuery());

        return View(teachers);
    }

    [HttpGet]
    [ResponseCache(Duration = 290, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<IActionResult> Details(Guid id)
    {
        var teacher = await _mediator.Send(new GetTeacherByIdQuery(id));

        if (teacher is null)
        {
            return NotFound($"Teacher with id {id} is not found.");
        }
        
        return View(teacher);
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

    [HttpPut]
    public async Task<IActionResult> Edit(Guid id, [FromBody] TeacherForUpdateDto? teacher)
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

    [HttpDelete]
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
