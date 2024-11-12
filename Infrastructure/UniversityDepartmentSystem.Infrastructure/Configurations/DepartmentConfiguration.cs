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

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasData(
            new Department { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Кафедра Прикладной Математики", IsGraduating = true, FacultyId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new Department { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Кафедра Философии", IsGraduating = false, FacultyId = Guid.Parse("22222222-2222-2222-2222-222222222222") }
        );
    }
}