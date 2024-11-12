using Microsoft.EntityFrameworkCore;
using UniversityDepartmentSystem.Domain.Entities;
using UniversityDepartmentSystem.Domain.Abstractions;

namespace UniversityDepartmentSystem.Infrastructure.Repositories;

public class DepartmentRepository(AppDbContext dbContext) : IDepartmentRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(Department entity) => await _dbContext.Departments.AddAsync(entity);

    public async Task<IEnumerable<Department>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.Departments.Include(e => e.Specialties).Include(e => e.Faculty).AsNoTracking() 
            : _dbContext.Departments.Include(e => e.Specialties).Include(e => e.Faculty)).ToListAsync();

    public async Task<Department?> GetById(Guid id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.Departments.Include(e => e.Specialties).Include(e => e.Faculty).AsNoTracking() :
            _dbContext.Departments.Include(e => e.Specialties).Include(e => e.Faculty)).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(Department entity) => _dbContext.Departments.Remove(entity);

    public void Update(Department entity) => _dbContext.Departments.Update(entity);

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}

