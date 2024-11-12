using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Queries;

public record GetSpecialtiesQuery : IRequest<IEnumerable<SpecialtyDto>>;
