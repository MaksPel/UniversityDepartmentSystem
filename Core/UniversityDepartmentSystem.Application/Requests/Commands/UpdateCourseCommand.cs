using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record UpdateCourseCommand(CourseForUpdateDto Course) : IRequest<bool>;
