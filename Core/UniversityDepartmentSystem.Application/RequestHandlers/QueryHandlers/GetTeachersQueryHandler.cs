using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Queries;

namespace UniversityDepartmentSystem.Application.RequestHandlers.QueryHandlers;

public class GetTeachersQueryHandler : IRequestHandler<GetTeachersQuery, IEnumerable<TeacherDto>>
{
	private readonly ITeacherRepository _repository;
	private readonly IMapper _mapper;

	public GetTeachersQueryHandler(ITeacherRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<TeacherDto>> Handle(GetTeachersQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<IEnumerable<TeacherDto>>(await _repository.Get(trackChanges: false));
}
