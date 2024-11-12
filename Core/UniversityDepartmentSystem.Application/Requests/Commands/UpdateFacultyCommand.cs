using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record UpdateFacultyCommand(FacultyForUpdateDto Faculty) : IRequest<bool>;
