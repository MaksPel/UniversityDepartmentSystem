using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Queries;

public record GetTeacherByIdQuery(Guid Id) : IRequest<TeacherDto?>;
