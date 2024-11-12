using MediatR;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record DeleteSubjectCommand(Guid Id) : IRequest<bool>;
