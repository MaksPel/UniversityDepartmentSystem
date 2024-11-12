using MediatR;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record DeleteDepartmentCommand(Guid Id) : IRequest<bool>;
