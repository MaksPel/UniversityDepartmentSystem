using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record CreateFacultyCommand(FacultyForCreationDto Faculty) : IRequest;
