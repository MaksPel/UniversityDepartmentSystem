using MediatR;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Application.RequestHandlers.CommandHandlers;

public class DeleteSpecialtyCommandHandler(ISpecialtyRepository repository) : IRequestHandler<DeleteSpecialtyCommand, bool>
{
	private readonly ISpecialtyRepository _repository = repository;

	public async Task<bool> Handle(DeleteSpecialtyCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.Id, trackChanges: false);

        if (entity is null)
        {
            return false;
        }

        _repository.Delete(entity);
        await _repository.SaveChanges();

        return true;
	}
}
