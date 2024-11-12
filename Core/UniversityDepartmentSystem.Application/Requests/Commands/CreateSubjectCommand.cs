using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Commands;

public record CreateSubjectCommand(SubjectForCreationDto Subject) : IRequest;
