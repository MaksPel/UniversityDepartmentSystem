using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Application.RequestHandlers.CommandHandlers;

public class UpdateFacultyCommandHandler : IRequestHandler<UpdateFacultyCommand, bool>
{
	private readonly IFacultyRepository _repository;
	private readonly IMapper _mapper;

	public UpdateFacultyCommandHandler(IFacultyRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<bool> Handle(UpdateFacultyCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.Faculty.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

		_mapper.Map(request.Faculty, entity);

		_repository.Update(entity);
		await _repository.SaveChanges();

		return true;
	}
}
