using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Queries;

namespace UniversityDepartmentSystem.Application.RequestHandlers.QueryHandlers;

public class GetSpecialtyByIdQueryHandler : IRequestHandler<GetSpecialtyByIdQuery, SpecialtyDto?>
{
	private readonly ISpecialtyRepository _repository;
	private readonly IMapper _mapper;

	public GetSpecialtyByIdQueryHandler(ISpecialtyRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<SpecialtyDto?> Handle(GetSpecialtyByIdQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<SpecialtyDto>(await _repository.GetById(request.Id, trackChanges: false));
}
