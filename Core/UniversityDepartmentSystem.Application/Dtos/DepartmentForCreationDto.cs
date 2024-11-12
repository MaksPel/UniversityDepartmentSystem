namespace UniversityDepartmentSystem.Application.Dtos;

public class DepartmentForCreationDto 
{
	public string Name { get; set; }
	public bool IsGraduating { get; set; }
	public Guid FacultyId { get; set; }
}

