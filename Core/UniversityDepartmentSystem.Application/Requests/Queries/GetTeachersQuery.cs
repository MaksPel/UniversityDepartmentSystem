﻿using MediatR;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application.Requests.Queries;

public record GetTeachersQuery : IRequest<IEnumerable<TeacherDto>>;
