using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Application.RequestHandlers.CommandHandlers;

public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, bool>
{
	private readonly ITeacherRepository _repository;
	private readonly IMapper _mapper;

	public UpdateTeacherCommandHandler(ITeacherRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<bool> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.Teacher.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

		_mapper.Map(request.Teacher, entity);

		_repository.Update(entity);
		await _repository.SaveChanges();

		return true;
	}
}
