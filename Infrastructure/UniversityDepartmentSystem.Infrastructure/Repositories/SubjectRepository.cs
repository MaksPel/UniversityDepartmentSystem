using Microsoft.EntityFrameworkCore;
using UniversityDepartmentSystem.Domain.Entities;
using UniversityDepartmentSystem.Domain.Abstractions;

namespace UniversityDepartmentSystem.Infrastructure.Repositories;

public class SubjectRepository(AppDbContext dbContext) : ISubjectRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(Subject entity) => await _dbContext.Subjects.AddAsync(entity);

    public async Task<IEnumerable<Subject>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.Subjects.AsNoTracking() 
            : _dbContext.Subjects).ToListAsync();

    public async Task<Subject?> GetById(Guid id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.Subjects.AsNoTracking() :
            _dbContext.Subjects).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(Subject entity) => _dbContext.Subjects.Remove(entity);

    public void Update(Subject entity) => _dbContext.Subjects.Update(entity);

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}

