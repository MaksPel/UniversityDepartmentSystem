using Microsoft.AspNetCore.Mvc;
﻿using MediatR;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Application.Requests.Queries;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.WebMVC.Controllers;

public class SubjectsController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ResponseCache(Duration = 290, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<IActionResult> Index()
    {
        var subjects = await _mediator.Send(new GetSubjectsQuery());

        return View(subjects);
    }

    [HttpGet]
    [ResponseCache(Duration = 290, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<IActionResult> Details(Guid id)
    {
        var subject = await _mediator.Send(new GetSubjectByIdQuery(id));

        if (subject is null)
        {
            return NotFound($"Subject with id {id} is not found.");
        }
        
        return View(subject);
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

    [HttpPut]
    public async Task<IActionResult> Edit(Guid id, [FromBody] SubjectForUpdateDto? subject)
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

    [HttpDelete]
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
