namespace UniversityDepartmentSystem.Domain.Entities;

public class Department 
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public bool IsGraduating { get; set; }
	public Guid FacultyId { get; set; }
	public Faculty Faculty { get; set; }
    public virtual ICollection<Specialty> Specialties { get; set; } = [];
}
