using UniversityDepartmentSystem.Domain.Entities;

namespace UniversityDepartmentSystem.Domain.Abstractions;

public interface IFacultyRepository 
{
	Task<IEnumerable<Faculty>> Get(bool trackChanges);
	Task<Faculty?> GetById(Guid id, bool trackChanges);
    Task Create(Faculty entity);
    void Delete(Faculty entity);
    void Update(Faculty entity);
    Task SaveChanges();
}

