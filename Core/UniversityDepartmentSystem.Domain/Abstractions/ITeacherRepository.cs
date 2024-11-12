using UniversityDepartmentSystem.Domain.Entities;

namespace UniversityDepartmentSystem.Domain.Abstractions;

public interface ITeacherRepository 
{
	Task<IEnumerable<Teacher>> Get(bool trackChanges);
	Task<Teacher?> GetById(Guid id, bool trackChanges);
    Task Create(Teacher entity);
    void Delete(Teacher entity);
    void Update(Teacher entity);
    Task SaveChanges();
}

