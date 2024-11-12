using Microsoft.EntityFrameworkCore;
using UniversityDepartmentSystem.Domain.Entities;
using UniversityDepartmentSystem.Domain.Abstractions;

namespace UniversityDepartmentSystem.Infrastructure.Repositories;

public class SpecialtyRepository(AppDbContext dbContext) : ISpecialtyRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(Specialty entity) => await _dbContext.Specialties.AddAsync(entity);

    public async Task<IEnumerable<Specialty>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.Specialties.Include(e => e.Courses).Include(e => e.Department).AsNoTracking() 
            : _dbContext.Specialties.Include(e => e.Courses).Include(e => e.Department)).ToListAsync();

    public async Task<Specialty?> GetById(Guid id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.Specialties.Include(e => e.Courses).Include(e => e.Department).AsNoTracking() :
            _dbContext.Specialties.Include(e => e.Courses).Include(e => e.Department)).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(Specialty entity) => _dbContext.Specialties.Remove(entity);

    public void Update(Specialty entity) => _dbContext.Specialties.Update(entity);

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}

