using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UniversityDepartmentSystem.Domain.Entities;
using System.Security.Cryptography;

namespace UniversityDepartmentSystem.Infrastructure.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasData(
            new Course { Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), CourseNumber = 1, SemesterNumber = 1, SpecialtyId = Guid.Parse("55555555-5555-5555-5555-555555555555") },
            new Course { Id = Guid.Parse("88888888-8888-8888-8888-888888888888"), CourseNumber = 2, SemesterNumber = 2, SpecialtyId = Guid.Parse("66666666-6666-6666-6666-666666666666") }
        );
    }
}