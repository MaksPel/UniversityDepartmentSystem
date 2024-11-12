using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Domain.Entities;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Application.RequestHandlers.CommandHandlers;

public class CreateSpecialtyCommandHandler : IRequestHandler<CreateSpecialtyCommand>
{
	private readonly ISpecialtyRepository _repository;
	private readonly IMapper _mapper;

	public CreateSpecialtyCommandHandler(ISpecialtyRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Handle(CreateSpecialtyCommand request, CancellationToken cancellationToken)
	{
		await _repository.Create(_mapper.Map<Specialty>(request.Specialty));
		await _repository.SaveChanges();
	}
}
