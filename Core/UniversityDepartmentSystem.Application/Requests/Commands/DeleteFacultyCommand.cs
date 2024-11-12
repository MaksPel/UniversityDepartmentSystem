using MediatR;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record DeleteFacultyCommand(Guid Id) : IRequest<bool>;
