using MediatR;
using AutoMapper;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Application.RequestHandlers.CommandHandlers;

public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, bool>
{
	private readonly ICourseRepository _repository;
	private readonly IMapper _mapper;

	public UpdateCourseCommandHandler(ICourseRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.Course.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

		_mapper.Map(request.Course, entity);

		_repository.Update(entity);
		await _repository.SaveChanges();

		return true;
	}
}
