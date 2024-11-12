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

public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
{
    public void Configure(EntityTypeBuilder<Specialty> builder)
    {
        builder.HasData(
            new Specialty { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Прикладная Математика", DepartmentId = Guid.Parse("33333333-3333-3333-3333-333333333333") },
            new Specialty { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Name = "Философия", DepartmentId = Guid.Parse("44444444-4444-4444-4444-444444444444") }
        );
    }
}