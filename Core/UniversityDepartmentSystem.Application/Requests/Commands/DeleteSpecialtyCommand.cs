using MediatR;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record DeleteSpecialtyCommand(Guid Id) : IRequest<bool>;
