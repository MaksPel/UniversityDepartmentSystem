using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record UpdateTeacherCommand(TeacherForUpdateDto Teacher) : IRequest<bool>;
