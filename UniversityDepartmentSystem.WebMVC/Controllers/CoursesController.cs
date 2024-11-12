using Microsoft.AspNetCore.Mvc;
﻿using MediatR;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Application.Requests.Queries;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.WebMVC.Controllers;

public class CoursesController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ResponseCache(Duration = 290, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<IActionResult> Index()
    {
        var courses = await _mediator.Send(new GetCoursesQuery());

        return View(courses);
    }

    [HttpGet]
    [ResponseCache(Duration = 290, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<IActionResult> Details(Guid id)
    {
        var course = await _mediator.Send(new GetCourseByIdQuery(id));

        if (course is null)
        {
            return NotFound($"Course with id {id} is not found.");
        }
        
        return View(course);
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

    [HttpPut]
    public async Task<IActionResult> Edit(Guid id, [FromBody] CourseForUpdateDto? course)
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

    [HttpDelete]
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
