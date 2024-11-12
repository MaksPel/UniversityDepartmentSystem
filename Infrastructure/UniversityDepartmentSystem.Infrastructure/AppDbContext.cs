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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__C92D7187910A3D82");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CourseID");
            entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

            entity.HasOne(d => d.Specialty).WithMany(p => p.Courses)
                .HasForeignKey(d => d.SpecialtyId)
                .HasConstraintName("FK__Courses__Special__284DF453");

            entity.HasMany(d => d.Subjects).WithMany(p => p.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseSubject",
                    r => r.HasOne<Subject>().WithMany()
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK__CourseSub__Subje__2C1E8537"),
                    l => l.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK__CourseSub__Cours__2B2A60FE"),
                    j =>
                    {
                        j.HasKey("CourseId", "SubjectId").HasName("PK__CourseSu__53ECCBBFF479D62D");
                        j.ToTable("CourseSubjects");
                        j.IndexerProperty<Guid>("CourseId").HasColumnName("CourseID");
                        j.IndexerProperty<Guid>("SubjectId").HasColumnName("SubjectID");
                    });
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__B2079BCDC68115CB");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("DepartmentID");
            entity.Property(e => e.FacultyId).HasColumnName("FacultyID");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Faculty).WithMany(p => p.Departments)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK__Departmen__Facul__1CDC41A7");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Facultie__306F636EE0AD0A7E");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("FacultyID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Specialty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Specialt__D768F648C8AE8A40");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("SpecialtyID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Department).WithMany(p => p.Specialties)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Specialti__Depar__20ACD28B");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subjects__AC1BA388DEAEF0C4");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("SubjectID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ReportingType).HasMaxLength(255);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teachers__EDF25944186BA0B6");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("TeacherID");
            entity.Property(e => e.Midname).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Position).HasMaxLength(255);
            entity.Property(e => e.Surname).HasMaxLength(255);

            entity.HasMany(d => d.Subjects).WithMany(p => p.Teachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeacherSubject",
                    r => r.HasOne<Subject>().WithMany()
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK__TeacherSu__Subje__32CB82C6"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("FK__TeacherSu__Teach__31D75E8D"),
                    j =>
                    {
                        j.HasKey("TeacherId", "SubjectId").HasName("PK__TeacherS__7733E37C96962DFB");
                        j.ToTable("TeacherSubjects");
                        j.IndexerProperty<Guid>("TeacherId").HasColumnName("TeacherID");
                        j.IndexerProperty<Guid>("SubjectId").HasColumnName("SubjectID");
                    });
        });

    }

}

