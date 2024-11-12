using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record CreateSpecialtyCommand(SpecialtyForCreationDto Specialty) : IRequest;
