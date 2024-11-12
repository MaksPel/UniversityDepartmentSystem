using UniversityDepartmentSystem.Domain.Entities;

namespace UniversityDepartmentSystem.Application.Dtos;

public class FacultyDto 
{
	public Guid Id { get; set; }
	public string Name { get; set; }
    public ICollection<Department> Departments { get; set; } 
}

