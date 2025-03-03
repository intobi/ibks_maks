using Microsoft.EntityFrameworkCore;
using Support.Domain.Entities;
using Support.Infrastructure.Persistence.DbContext;

namespace Support.Infrastructure.Persistence.Repositories;

public class RepliesRepository(SupportDbContext context) : RepositoryBase<TicketReply>(context)
{
    public override async Task<List<TicketReply>> GetAllAsync(int page, int pageSize, params string[] additional)
    {
        return await DbSet
            .Where(x => x.TId == long.Parse(additional[0]))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}