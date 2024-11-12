using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Queries;

namespace UniversityDepartmentSystem.Application.RequestHandlers.QueryHandlers;

public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, TeacherDto?>
{
	private readonly ITeacherRepository _repository;
	private readonly IMapper _mapper;

	public GetTeacherByIdQueryHandler(ITeacherRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<TeacherDto?> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<TeacherDto>(await _repository.GetById(request.Id, trackChanges: false));
}
