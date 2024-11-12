using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Application.Dtos;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Queries;

namespace UniversityDepartmentSystem.Application.RequestHandlers.QueryHandlers;

public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDto?>
{
	private readonly ICourseRepository _repository;
	private readonly IMapper _mapper;

	public GetCourseByIdQueryHandler(ICourseRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<CourseDto?> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<CourseDto>(await _repository.GetById(request.Id, trackChanges: false));
}
