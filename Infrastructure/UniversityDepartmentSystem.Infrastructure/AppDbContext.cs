using Microsoft.EntityFrameworkCore;
using UniversityDepartmentSystem.Domain.Entities;

namespace UniversityDepartmentSystem.Infrastructure;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
	public DbSet<Faculty> Faculties { get; set; }
	public DbSet<Department> Departments { get; set; }
	public DbSet<Specialty> Specialties { get; set; }
	public DbSet<Course> Courses { get; set; }
	public DbSet<Subject> Subjects { get; set; }
	public DbSet<Teacher> Teachers { get; set; }
}

