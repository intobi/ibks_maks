using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Support.Application.Common.Interfaces;
using Support.Infrastructure.Persistence.DbContext;

namespace Support.Infrastructure.Persistence.Repositories;

public abstract class RepositoryBase<TEntity>(SupportDbContext context) : IRepositoryBase<TEntity> where TEntity : class
{
    protected SupportDbContext Context { get; private set; } = context;
    protected DbSet<TEntity> DbSet { get; private set; } = context.Set<TEntity>();

    public virtual async Task<List<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task<List<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await DbSet.Where(expression).ToListAsync();
    }

    public virtual async Task<TEntity?> FindByIdAsync(object id) => await DbSet.FindAsync(id);

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DbSet.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity?> DeleteAsync(object id)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity == null)
            return entity;

        DbSet.Attach(entity);
        DbSet.Remove(entity);
        await Context.SaveChangesAsync();

        return entity;
    }
}
