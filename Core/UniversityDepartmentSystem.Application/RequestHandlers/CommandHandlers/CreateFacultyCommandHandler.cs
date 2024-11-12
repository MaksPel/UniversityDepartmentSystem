using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Domain.Entities;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Application.RequestHandlers.CommandHandlers;

public class CreateFacultyCommandHandler : IRequestHandler<CreateFacultyCommand>
{
	private readonly IFacultyRepository _repository;
	private readonly IMapper _mapper;

	public CreateFacultyCommandHandler(IFacultyRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
	{
		await _repository.Create(_mapper.Map<Faculty>(request.Faculty));
		await _repository.SaveChanges();
	}
}
