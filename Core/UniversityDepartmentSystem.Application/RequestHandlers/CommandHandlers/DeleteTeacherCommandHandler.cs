﻿using MediatR;
using UniversityDepartmentSystem.Domain.Abstractions;
using UniversityDepartmentSystem.Application.Requests.Commands;

namespace UniversityDepartmentSystem.Application.RequestHandlers.CommandHandlers;

public class DeleteTeacherCommandHandler(ITeacherRepository repository) : IRequestHandler<DeleteTeacherCommand, bool>
{
	private readonly ITeacherRepository _repository = repository;

	public async Task<bool> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
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
