using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Queries;

namespace UniversityDepartmentSystem.Application.RequestHandlers.QueryHandlers;

public class GetSubjectsQueryHandler : IRequestHandler<GetSubjectsQuery, IEnumerable<SubjectDto>>
{
	private readonly ISubjectRepository _repository;
	private readonly IMapper _mapper;

	public GetSubjectsQueryHandler(ISubjectRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<SubjectDto>> Handle(GetSubjectsQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<IEnumerable<SubjectDto>>(await _repository.Get(trackChanges: false));
}
