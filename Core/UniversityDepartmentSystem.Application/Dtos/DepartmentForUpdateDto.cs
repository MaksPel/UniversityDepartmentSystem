namespace UniversityDepartmentSystem.Application.Dtos;

public class DepartmentForUpdateDto 
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public bool IsGraduating { get; set; }
	public Guid FacultyId { get; set; }
}

