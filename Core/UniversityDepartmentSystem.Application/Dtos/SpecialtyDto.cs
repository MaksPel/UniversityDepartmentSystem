using UniversityDepartmentSystem.Domain.Entities;

namespace UniversityDepartmentSystem.Application.Dtos;

public class SpecialtyDto 
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public Guid DepartmentId { get; set; }
	public DepartmentDto Department { get; set; }
    public ICollection<Course> Courses { get; set; }
}

