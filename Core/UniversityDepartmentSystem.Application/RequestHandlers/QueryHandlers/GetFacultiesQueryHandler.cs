using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Queries;

namespace UniversityDepartmentSystem.Application.RequestHandlers.QueryHandlers;

public class GetFacultiesQueryHandler : IRequestHandler<GetFacultiesQuery, IEnumerable<FacultyDto>>
{
	private readonly IFacultyRepository _repository;
	private readonly IMapper _mapper;

	public GetFacultiesQueryHandler(IFacultyRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<FacultyDto>> Handle(GetFacultiesQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<IEnumerable<FacultyDto>>(await _repository.Get(trackChanges: false));
}
