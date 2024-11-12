using MediatR;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record DeleteTeacherCommand(Guid Id) : IRequest<bool>;
