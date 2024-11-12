using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Domain.Entities;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Application.RequestHandlers.CommandHandlers;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand>
{
	private readonly ICourseRepository _repository;
	private readonly IMapper _mapper;

	public CreateCourseCommandHandler(ICourseRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Handle(CreateCourseCommand request, CancellationToken cancellationToken)
	{
		await _repository.Create(_mapper.Map<Course>(request.Course));
		await _repository.SaveChanges();
	}
}
