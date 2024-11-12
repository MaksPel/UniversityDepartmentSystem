using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Queries;

public record GetFacultyByIdQuery(Guid Id) : IRequest<FacultyDto?>;
