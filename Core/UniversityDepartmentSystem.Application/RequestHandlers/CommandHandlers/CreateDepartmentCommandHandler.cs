using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Domain.Entities;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Application.RequestHandlers.CommandHandlers;

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand>
{
	private readonly IDepartmentRepository _repository;
	private readonly IMapper _mapper;

	public CreateDepartmentCommandHandler(IDepartmentRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
	{
		await _repository.Create(_mapper.Map<Department>(request.Department));
		await _repository.SaveChanges();
	}
}
