using AutoMapper;
using UniversityDepartmentSystem.Domain.Entities;
using UniversityDepartmentSystem.Application.Dtos;

namespace UniversityDepartmentSystem.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
		CreateMap<Faculty, FacultyDto>();
		CreateMap<FacultyForCreationDto, Faculty>();
		CreateMap<FacultyForUpdateDto, Faculty>();

		CreateMap<Department, DepartmentDto>();
		CreateMap<DepartmentForCreationDto, Department>();
		CreateMap<DepartmentForUpdateDto, Department>();

		CreateMap<Specialty, SpecialtyDto>();
		CreateMap<SpecialtyForCreationDto, Specialty>();
		CreateMap<SpecialtyForUpdateDto, Specialty>();

		CreateMap<Course, CourseDto>();
		CreateMap<CourseForCreationDto, Course>();
		CreateMap<CourseForUpdateDto, Course>();

		CreateMap<Subject, SubjectDto>();
		CreateMap<SubjectForCreationDto, Subject>();
		CreateMap<SubjectForUpdateDto, Subject>();

		CreateMap<Teacher, TeacherDto>();
		CreateMap<TeacherForCreationDto, Teacher>();
		CreateMap<TeacherForUpdateDto, Teacher>();
    }
}

