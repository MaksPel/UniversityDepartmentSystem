namespace UniversityDepartmentSystem.Domain.Entities;

public class Specialty 
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public Guid DepartmentId { get; set; }
	public Department Department { get; set; }
    public virtual ICollection<Course> Courses { get; set; } = [];
}
