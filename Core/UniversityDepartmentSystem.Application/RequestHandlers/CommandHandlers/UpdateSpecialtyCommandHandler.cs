using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Application.RequestHandlers.CommandHandlers;

public class UpdateSpecialtyCommandHandler : IRequestHandler<UpdateSpecialtyCommand, bool>
{
	private readonly ISpecialtyRepository _repository;
	private readonly IMapper _mapper;

	public UpdateSpecialtyCommandHandler(ISpecialtyRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<bool> Handle(UpdateSpecialtyCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.Specialty.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

		_mapper.Map(request.Specialty, entity);

		_repository.Update(entity);
		await _repository.SaveChanges();

		return true;
	}
}
