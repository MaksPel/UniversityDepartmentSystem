using Microsoft.EntityFrameworkCore;
using UniversityDepartmentSystem.Domain.Entities;
using UniversityDepartmentSystem.Domain.Abstractions;

namespace UniversityDepartmentSystem.Infrastructure.Repositories;

public class CourseRepository(AppDbContext dbContext) : ICourseRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(Course entity) => await _dbContext.Courses.AddAsync(entity);

    public async Task<IEnumerable<Course>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.Courses.Include(e => e.Specialty).AsNoTracking() 
            : _dbContext.Courses.Include(e => e.Specialty)).ToListAsync();

    public async Task<Course?> GetById(Guid id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.Courses.Include(e => e.Specialty).AsNoTracking() :
            _dbContext.Courses.Include(e => e.Specialty)).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(Course entity) => _dbContext.Courses.Remove(entity);

    public void Update(Course entity) => _dbContext.Courses.Update(entity);

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}

