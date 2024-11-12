using Microsoft.EntityFrameworkCore;
using UniversityDepartmentSystem.Domain.Entities;
using UniversityDepartmentSystem.Domain.Abstractions;

namespace UniversityDepartmentSystem.Infrastructure.Repositories;

public class FacultyRepository(AppDbContext dbContext) : IFacultyRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(Faculty entity) => await _dbContext.Faculties.AddAsync(entity);

    public async Task<IEnumerable<Faculty>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.Faculties.Include(e => e.Departments).AsNoTracking() 
            : _dbContext.Faculties.Include(e => e.Departments)).ToListAsync();

    public async Task<Faculty?> GetById(Guid id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.Faculties.Include(e => e.Departments).AsNoTracking() :
            _dbContext.Faculties.Include(e => e.Departments)).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(Faculty entity) => _dbContext.Faculties.Remove(entity);

    public void Update(Faculty entity) => _dbContext.Faculties.Update(entity);

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}

