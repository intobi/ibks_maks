using Support.Domain.Entities;
using Support.Infrastructure.Persistence.DbContext;

namespace Support.Infrastructure.Persistence.Repositories;

public class TicketTypesRepository(SupportDbContext context) : RepositoryBase<TicketType>(context)
{
    
}