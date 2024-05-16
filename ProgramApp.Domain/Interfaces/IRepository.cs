namespace ProgramApp.Domain.Interfaces;

public interface IRepository<TEntity>
{
    public Task<TEntity> Create(TEntity entity);
    public Task<TEntity> Update(Guid Id, TEntity entity);
    public Task<bool> Delete(Guid Id);
    public Task<TEntity?> GetById(Guid Id);
    public Task<IEnumerable<TEntity>> GetAll();
    public Task<bool> SaveChangesAsync();
}
