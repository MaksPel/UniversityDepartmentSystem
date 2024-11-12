namespace UniversityDepartmentSystem.Domain.Entities;

public class Course 
{
	public Guid Id { get; set; }
	public int CourseNumber { get; set; }
	public int SemesterNumber { get; set; }
	public Guid SpecialtyId { get; set; }
	public Specialty Specialty { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = [];
}
