using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Application.RequestHandlers.CommandHandlers;

public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, bool>
{
	private readonly ISubjectRepository _repository;
	private readonly IMapper _mapper;

	public UpdateSubjectCommandHandler(ISubjectRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<bool> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.Subject.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

		_mapper.Map(request.Subject, entity);

		_repository.Update(entity);
		await _repository.SaveChanges();

		return true;
	}
}
