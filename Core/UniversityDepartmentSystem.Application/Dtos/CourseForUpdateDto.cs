namespace UniversityDepartmentSystem.Application.Dtos;

public class CourseForUpdateDto 
{
	public Guid Id { get; set; }
	public int CourseNumber { get; set; }
	public int SemesterNumber { get; set; }
	public Guid SpecialtyId { get; set; }
}

