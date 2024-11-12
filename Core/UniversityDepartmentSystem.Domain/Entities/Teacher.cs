namespace UniversityDepartmentSystem.Domain.Entities;

public class Teacher 
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public string Midname { get; set; }
	public string Position { get; set; }
	public int Age { get; set; }
}
