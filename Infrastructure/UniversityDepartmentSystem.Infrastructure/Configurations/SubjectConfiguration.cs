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

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasData(
            new Subject { Id = Guid.Parse("99999999-9999-9999-9999-999999999999"), Name = "Алгебра", LectureHours = 30, PracticalHours = 15, LabHours = 5, ReportingType = "Экзамен" },
            new Subject { Id = Guid.Parse("99999999-9999-9999-9199-999999999999"), Name = "Этика", LectureHours = 20, PracticalHours = 10, LabHours = 0, ReportingType = "Зачет" }
        );
    }
}