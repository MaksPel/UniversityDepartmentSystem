using Microsoft.EntityFrameworkCore;
using UniversityDepartmentSystem.Domain.Entities;
using UniversityDepartmentSystem.Domain.Abstractions;

namespace UniversityDepartmentSystem.Infrastructure.Repositories;

public class TeacherRepository(AppDbContext dbContext) : ITeacherRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(Teacher entity) => await _dbContext.Teachers.AddAsync(entity);

    public async Task<IEnumerable<Teacher>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.Teachers.Include(e => e.Subjects).AsNoTracking() 
            : _dbContext.Teachers.Include(e => e.Subjects)).ToListAsync();

    public async Task<Teacher?> GetById(Guid id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.Teachers.Include(e => e.Subjects).AsNoTracking() :
            _dbContext.Teachers.Include(e => e.Subjects)).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(Teacher entity) => _dbContext.Teachers.Remove(entity);

    public void Update(Teacher entity) => _dbContext.Teachers.Update(entity);

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}

