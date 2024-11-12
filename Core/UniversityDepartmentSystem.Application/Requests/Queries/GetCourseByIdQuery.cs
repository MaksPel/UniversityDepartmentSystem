using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Queries;

public record GetCourseByIdQuery(Guid Id) : IRequest<CourseDto?>;
