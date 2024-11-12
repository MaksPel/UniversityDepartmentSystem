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

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasData(
            new Teacher { Id = Guid.Parse("99999999-9999-9999-9999-999999299999"), Name = "Иван", Surname = "Иванов", Midname = "Иванович", Position = "Доцент", Age = 40 },
            new Teacher { Id = Guid.Parse("99999999-9999-9999-9999-999999969999"), Name = "Мария", Surname = "Петрова", Midname = "Сергеевна", Position = "Преподаватель", Age = 40 }
        );
    }
}