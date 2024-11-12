namespace UniversityDepartmentSystem.Application.Dtos;

public class SubjectForUpdateDto 
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public int LectureHours { get; set; }
	public int PracticalHours { get; set; }
	public int LabHours { get; set; }
	public string ReportingType { get; set; }
}

