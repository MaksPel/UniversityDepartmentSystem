namespace UniversityDepartmentSystem.Domain.Entities;

public class Faculty 
{
	public Guid Id { get; set; }
	public string Name { get; set; }
    public virtual ICollection<Department> Departments { get; set; } = [];
}
