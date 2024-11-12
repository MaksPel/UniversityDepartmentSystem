using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Queries;

public record GetDepartmentByIdQuery(Guid Id) : IRequest<DepartmentDto?>;
