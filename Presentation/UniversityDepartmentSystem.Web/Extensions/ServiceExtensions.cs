using Microsoft.EntityFrameworkCore;
using UniversityDepartmentSystem.Infrastructure;
using UniversityDepartmentSystem.Infrastructure.Repositories;
using UniversityDepartmentSystem.Domain.Abstractions;

namespace UniversityDepartmentSystem.Web.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("DbConnection"), b =>
                b.MigrationsAssembly("UniversityDepartmentSystem.Infrastructure")));
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
		services.AddScoped<IFacultyRepository, FacultyRepository>();
		services.AddScoped<IDepartmentRepository, DepartmentRepository>();
		services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
		services.AddScoped<ICourseRepository, CourseRepository>();
		services.AddScoped<ISubjectRepository, SubjectRepository>();
		services.AddScoped<ITeacherRepository, TeacherRepository>();
    }
}
