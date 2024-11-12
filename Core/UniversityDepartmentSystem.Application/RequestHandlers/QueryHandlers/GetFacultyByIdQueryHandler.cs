using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Queries;

namespace UniversityDepartmentSystem.Application.RequestHandlers.QueryHandlers;

public class GetFacultyByIdQueryHandler : IRequestHandler<GetFacultyByIdQuery, FacultyDto?>
{
	private readonly IFacultyRepository _repository;
	private readonly IMapper _mapper;

	public GetFacultyByIdQueryHandler(IFacultyRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<FacultyDto?> Handle(GetFacultyByIdQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<FacultyDto>(await _repository.GetById(request.Id, trackChanges: false));
}
