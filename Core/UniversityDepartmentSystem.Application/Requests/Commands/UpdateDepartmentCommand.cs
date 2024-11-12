using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record UpdateDepartmentCommand(DepartmentForUpdateDto Department) : IRequest<bool>;
