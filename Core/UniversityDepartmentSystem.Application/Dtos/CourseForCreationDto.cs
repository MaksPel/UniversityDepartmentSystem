namespace UniversityDepartmentSystem.Application.Dtos;

public class CourseForCreationDto 
{
	public int CourseNumber { get; set; }
	public int SemesterNumber { get; set; }
	public Guid SpecialtyId { get; set; }
}

