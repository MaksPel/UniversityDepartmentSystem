using UniversityDepartmentSystem.Domain.Entities;

namespace UniversityDepartmentSystem.Domain.Abstractions;

public interface ISubjectRepository 
{
	Task<IEnumerable<Subject>> Get(bool trackChanges);
	Task<Subject?> GetById(Guid id, bool trackChanges);
    Task Create(Subject entity);
    void Delete(Subject entity);
    void Update(Subject entity);
    Task SaveChanges();
}

