using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Queries;

public record GetFacultiesQuery : IRequest<IEnumerable<FacultyDto>>;
