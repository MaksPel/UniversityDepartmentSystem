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

public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        builder.HasData(
            new Faculty { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Факультет Инженерии" },
            new Faculty { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Факультет Гуманитарных Наук" }
        );
    }
}