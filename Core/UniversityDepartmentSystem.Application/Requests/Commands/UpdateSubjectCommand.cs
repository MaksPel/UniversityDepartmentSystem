using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record UpdateSubjectCommand(SubjectForUpdateDto Subject) : IRequest<bool>;
