using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Domain.Entities;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Application.RequestHandlers.CommandHandlers;

public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand>
{
	private readonly ITeacherRepository _repository;
	private readonly IMapper _mapper;

	public CreateTeacherCommandHandler(ITeacherRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
	{
		await _repository.Create(_mapper.Map<Teacher>(request.Teacher));
		await _repository.SaveChanges();
	}
}
