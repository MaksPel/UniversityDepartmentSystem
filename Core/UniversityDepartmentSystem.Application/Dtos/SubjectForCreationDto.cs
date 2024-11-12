namespace UniversityDepartmentSystem.Application.Dtos;

public class SubjectForCreationDto 
{
	public string Name { get; set; }
	public int LectureHours { get; set; }
	public int PracticalHours { get; set; }
	public int LabHours { get; set; }
	public string ReportingType { get; set; }
}

