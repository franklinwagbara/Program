using Microsoft.EntityFrameworkCore;
using ProgramApp.Application.Exceptions;
using ProgramApp.Domain.Interfaces;

namespace ProgramApp.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context) 
    { 
        _context = context;
    }
    public async Task<TEntity> Create(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task<bool> Delete(Guid Id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(Id) ?? throw new NotFoundException();
        _context.Set<TEntity>().Remove(entity);
        return true;
    }

    public async Task<IEnumerable<TEntity>?> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetById(Guid Id)
    {
        return await _context.Set<TEntity>().FindAsync(Id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        var res = await _context.SaveChangesAsync();
        return res >= 0;
    }

    public async Task<TEntity> Update(Guid Id, TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _ = await _context.Set<TEntity>().FindAsync(Id) ?? throw new NotFoundException();
        _context.Set<TEntity>().Update(entity);
        return entity;
    }
}
