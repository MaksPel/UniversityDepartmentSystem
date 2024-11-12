﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityDepartmentSystem.Infrastructure;

#nullable disable

namespace UniversityDepartmentSystem.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseSubject", b =>
                {
                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CourseID");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SubjectID");

                    b.HasKey("CourseId", "SubjectId")
                        .HasName("PK__CourseSu__53ECCBBFF479D62D");

                    b.HasIndex("SubjectId");

                    b.ToTable("CourseSubjects", (string)null);
                });

            modelBuilder.Entity("TeacherSubject", b =>
                {
                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TeacherID");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SubjectID");

                    b.HasKey("TeacherId", "SubjectId")
                        .HasName("PK__TeacherS__7733E37C96962DFB");

                    b.HasIndex("SubjectId");

                    b.ToTable("TeacherSubjects", (string)null);
                });

            modelBuilder.Entity("UniversityDepartmentSystem.Domain.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CourseID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("CourseNumber")
                        .HasColumnType("int");

                    b.Property<int>("SemesterNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("SpecialtyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SpecialtyID");

                    b.HasKey("Id")
                        .HasName("PK__Courses__C92D7187910A3D82");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777777777"),
                            CourseNumber = 1,
                            SemesterNumber = 1,
                            SpecialtyId = new Guid("55555555-5555-5555-5555-555555555555")
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888888888"),
                            CourseNumber = 2,
                            SemesterNumber = 2,
                            SpecialtyId = new Guid("66666666-6666-6666-6666-666666666666")
                        });
                });

            modelBuilder.Entity("UniversityDepartmentSystem.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DepartmentID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("FacultyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FacultyID");

                    b.Property<bool>("IsGraduating")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Departme__B2079BCDC68115CB");

                    b.HasIndex("FacultyId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("33333333-3333-3333-3333-333333333333"),
                            FacultyId = new Guid("11111111-1111-1111-1111-111111111111"),
                            IsGraduating = true,
                            Name = "Кафедра Прикладной Математики"
                        },
                        new
                        {
                            Id = new Guid("44444444-4444-4444-4444-444444444444"),
                            FacultyId = new Guid("22222222-2222-2222-2222-222222222222"),
                            IsGraduating = false,
                            Name = "Кафедра Философии"
                        });
                });

            modelBuilder.Entity("UniversityDepartmentSystem.Domain.Entities.Faculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FacultyID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Facultie__306F636EE0AD0A7E");

                    b.ToTable("Faculties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            Name = "Факультет Инженерии"
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            Name = "Факультет Гуманитарных Наук"
                        });
                });

            modelBuilder.Entity("UniversityDepartmentSystem.Domain.Entities.Specialty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SpecialtyID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DepartmentID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Specialt__D768F648C8AE8A40");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Specialties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("55555555-5555-5555-5555-555555555555"),
                            DepartmentId = new Guid("33333333-3333-3333-3333-333333333333"),
                            Name = "Прикладная Математика"
                        },
                        new
                        {
                            Id = new Guid("66666666-6666-6666-6666-666666666666"),
                            DepartmentId = new Guid("44444444-4444-4444-4444-444444444444"),
                            Name = "Философия"
                        });
                });

            modelBuilder.Entity("UniversityDepartmentSystem.Domain.Entities.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SubjectID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("LabHours")
                        .HasColumnType("int");

                    b.Property<int>("LectureHours")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PracticalHours")
                        .HasColumnType("int");

                    b.Property<string>("ReportingType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Subjects__AC1BA388DEAEF0C4");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999999999"),
                            LabHours = 5,
                            LectureHours = 30,
                            Name = "Алгебра",
                            PracticalHours = 15,
                            ReportingType = "Экзамен"
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9199-999999999999"),
                            LabHours = 0,
                            LectureHours = 20,
                            Name = "Этика",
                            PracticalHours = 10,
                            ReportingType = "Зачет"
                        });
                });

            modelBuilder.Entity("UniversityDepartmentSystem.Domain.Entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TeacherID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Midname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Teachers__EDF25944186BA0B6");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999299999"),
                            Age = 40,
                            Midname = "Иванович",
                            Name = "Иван",
                            Position = "Доцент",
                            Surname = "Иванов"
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999969999"),
                            Age = 40,
                            Midname = "Сергеевна",
                            Name = "Мария",
                            Position = "Преподаватель",
                            Surname = "Петрова"
                        });
                });

            modelBuilder.Entity("CourseSubject", b =>
                {
                    b.HasOne("UniversityDepartmentSystem.Domain.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__CourseSub__Cours__2B2A60FE");

                    b.HasOne("UniversityDepartmentSystem.Domain.Entities.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__CourseSub__Subje__2C1E8537");
                });

            modelBuilder.Entity("TeacherSubject", b =>
                {
                    b.HasOne("UniversityDepartmentSystem.Domain.Entities.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__TeacherSu__Subje__32CB82C6");

                    b.HasOne("UniversityDepartmentSystem.Domain.Entities.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__TeacherSu__Teach__31D75E8D");
                });

            modelBuilder.Entity("UniversityDepartmentSystem.Domain.Entities.Course", b =>
                {
                    b.HasOne("UniversityDepartmentSystem.Domain.Entities.Specialty", "Specialty")
                        .WithMany("Courses")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Courses__Special__284DF453");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("UniversityDepartmentSystem.Domain.Entities.Department", b =>
                {
                    b.HasOne("UniversityDepartmentSystem.Domain.Entities.Faculty", "Faculty")
                        .WithMany("Departments")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Departmen__Facul__1CDC41A7");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("UniversityDepartmentSystem.Domain.Entities.Specialty", b =>
                {
                    b.HasOne("UniversityDepartmentSystem.Domain.Entities.Department", "Department")
                        .WithMany("Specialties")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Specialti__Depar__20ACD28B");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("UniversityDepartmentSystem.Domain.Entities.Department", b =>
                {
                    b.Navigation("Specialties");
                });

            modelBuilder.Entity("UniversityDepartmentSystem.Domain.Entities.Faculty", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("UniversityDepartmentSystem.Domain.Entities.Specialty", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
