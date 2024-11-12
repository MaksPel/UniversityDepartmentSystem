using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Queries;

public record GetSpecialtyByIdQuery(Guid Id) : IRequest<SpecialtyDto?>;
