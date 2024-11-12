using MediatR;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Application.RequestHandlers.CommandHandlers;

public class DeleteFacultyCommandHandler(IFacultyRepository repository) : IRequestHandler<DeleteFacultyCommand, bool>
{
	private readonly IFacultyRepository _repository = repository;

	public async Task<bool> Handle(DeleteFacultyCommand request, CancellationToken cancellationToken)
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
