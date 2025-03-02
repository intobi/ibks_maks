using Microsoft.EntityFrameworkCore;
using Support.Domain.Entities;
using Support.Infrastructure.Persistence.DbContext;

namespace Support.Infrastructure.Persistence.Repositories;

public class TicketsRepository(SupportDbContext context) : RepositoryBase<Ticket>(context)
{
    public override async Task<List<Ticket>> GetAllAsync(int page, int pageSize)
    {
        return await DbSet
            .Where(x => x.Deleted != true)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public override async Task<Ticket?> FindByIdAsync(object id)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id == (long)id && x.Deleted != true);
    }
}