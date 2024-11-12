using UniversityDepartmentSystem.Domain.Entities;

namespace UniversityDepartmentSystem.Domain.Abstractions;

public interface ICourseRepository 
{
	Task<IEnumerable<Course>> Get(bool trackChanges);
	Task<Course?> GetById(Guid id, bool trackChanges);
    Task Create(Course entity);
    void Delete(Course entity);
    void Update(Course entity);
    Task SaveChanges();
}

