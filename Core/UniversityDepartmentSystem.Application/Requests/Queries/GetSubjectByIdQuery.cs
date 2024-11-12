using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Queries;

public record GetSubjectByIdQuery(Guid Id) : IRequest<SubjectDto?>;
