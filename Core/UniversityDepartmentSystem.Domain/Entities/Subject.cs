namespace UniversityDepartmentSystem.Domain.Entities;

public class Subject 
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public int LectureHours { get; set; }
	public int PracticalHours { get; set; }
	public int LabHours { get; set; }
	public string ReportingType { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = [];

    public virtual ICollection<Teacher> Teachers { get; set; } = [];
}
