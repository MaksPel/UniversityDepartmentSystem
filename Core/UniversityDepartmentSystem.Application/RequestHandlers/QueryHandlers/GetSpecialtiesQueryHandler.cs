using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Queries;

namespace UniversityDepartmentSystem.Application.RequestHandlers.QueryHandlers;

public class GetSpecialtiesQueryHandler : IRequestHandler<GetSpecialtiesQuery, IEnumerable<SpecialtyDto>>
{
	private readonly ISpecialtyRepository _repository;
	private readonly IMapper _mapper;

	public GetSpecialtiesQueryHandler(ISpecialtyRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<SpecialtyDto>> Handle(GetSpecialtiesQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<IEnumerable<SpecialtyDto>>(await _repository.Get(trackChanges: false));
}
