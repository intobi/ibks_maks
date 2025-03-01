using Support.Domain.Entities;
using Support.Infrastructure.Persistence.DbContext;

namespace Support.Infrastructure.Persistence.Repositories;

public class PrioritiesRepository(SupportDbContext context) : RepositoryBase<Priority>(context)
{
    
}