namespace UniversityDepartmentSystem.Application.Dtos;

public class CourseDto 
{
	public Guid Id { get; set; }
	public int CourseNumber { get; set; }
	public int SemesterNumber { get; set; }
	public Guid SpecialtyId { get; set; }
	public SpecialtyDto Specialty { get; set; }
}

