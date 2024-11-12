using UniversityDepartmentSystem.Domain.Entities;

namespace UniversityDepartmentSystem.Domain.Abstractions;

public interface ISpecialtyRepository 
{
	Task<IEnumerable<Specialty>> Get(bool trackChanges);
	Task<Specialty?> GetById(Guid id, bool trackChanges);
    Task Create(Specialty entity);
    void Delete(Specialty entity);
    void Update(Specialty entity);
    Task SaveChanges();
}

