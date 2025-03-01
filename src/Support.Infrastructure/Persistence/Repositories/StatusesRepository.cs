using Support.Domain.Entities;
using Support.Infrastructure.Persistence.DbContext;

namespace Support.Infrastructure.Persistence.Repositories;

public class StatusesRepository(SupportDbContext context) : RepositoryBase<Status>(context)
{
    
}