namespace UniversityDepartmentSystem.Application.Dtos;

public class DepartmentDto 
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public bool IsGraduating { get; set; }
	public Guid FacultyId { get; set; }
	public FacultyDto Faculty { get; set; }
}

