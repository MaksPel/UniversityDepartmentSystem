using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Domain.Entities;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Application.RequestHandlers.CommandHandlers;

public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand>
{
	private readonly ISubjectRepository _repository;
	private readonly IMapper _mapper;

	public CreateSubjectCommandHandler(ISubjectRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
	{
		await _repository.Create(_mapper.Map<Subject>(request.Subject));
		await _repository.SaveChanges();
	}
}
