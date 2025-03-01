using Support.Domain.Entities;
using Support.Infrastructure.Persistence.DbContext;

namespace Support.Infrastructure.Persistence.Repositories;

public class RepliesRepository(SupportDbContext context) : RepositoryBase<TicketReply>(context)
{
    
}