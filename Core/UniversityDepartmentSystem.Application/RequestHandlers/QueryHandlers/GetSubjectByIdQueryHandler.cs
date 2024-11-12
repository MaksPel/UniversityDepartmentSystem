using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Queries;

namespace UniversityDepartmentSystem.Application.RequestHandlers.QueryHandlers;

public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, SubjectDto?>
{
	private readonly ISubjectRepository _repository;
	private readonly IMapper _mapper;

	public GetSubjectByIdQueryHandler(ISubjectRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<SubjectDto?> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<SubjectDto>(await _repository.GetById(request.Id, trackChanges: false));
}
