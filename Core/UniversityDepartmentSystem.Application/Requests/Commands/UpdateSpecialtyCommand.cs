using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record UpdateSpecialtyCommand(SpecialtyForUpdateDto Specialty) : IRequest<bool>;
