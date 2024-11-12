using MediatR;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record DeleteCourseCommand(Guid Id) : IRequest<bool>;
