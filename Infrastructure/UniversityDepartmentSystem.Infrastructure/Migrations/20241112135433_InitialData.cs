using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityDepartmentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "FacultyID", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Факультет Инженерии" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Факультет Гуманитарных Наук" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectID", "LabHours", "LectureHours", "Name", "PracticalHours", "ReportingType" },
                values: new object[,]
                {
                    { new Guid("99999999-9999-9999-9199-999999999999"), 0, 20, "Этика", 10, "Зачет" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), 5, 30, "Алгебра", 15, "Экзамен" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherID", "Age", "Midname", "Name", "Position", "Surname" },
                values: new object[,]
                {
                    { new Guid("99999999-9999-9999-9999-999999299999"), 40, "Иванович", "Иван", "Доцент", "Иванов" },
                    { new Guid("99999999-9999-9999-9999-999999969999"), 40, "Сергеевна", "Мария", "Преподаватель", "Петрова" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "FacultyID", "IsGraduating", "Name" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111"), true, "Кафедра Прикладной Математики" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("22222222-2222-2222-2222-222222222222"), false, "Кафедра Философии" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "SpecialtyID", "DepartmentID", "Name" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-5555-5555-555555555555"), new Guid("33333333-3333-3333-3333-333333333333"), "Прикладная Математика" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("44444444-4444-4444-4444-444444444444"), "Философия" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "CourseNumber", "SemesterNumber", "SpecialtyID" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777777"), 1, 1, new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("88888888-8888-8888-8888-888888888888"), 2, 2, new Guid("66666666-6666-6666-6666-666666666666") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: new Guid("99999999-9999-9999-9199-999999999999"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: new Guid("99999999-9999-9999-9999-999999299999"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: new Guid("99999999-9999-9999-9999-999999969999"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "SpecialtyID",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "SpecialtyID",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyID",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyID",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));
        }
    }
}
