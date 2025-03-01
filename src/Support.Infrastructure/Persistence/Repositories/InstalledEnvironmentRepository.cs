using Support.Domain.Entities;
using Support.Infrastructure.Persistence.DbContext;

namespace Support.Infrastructure.Persistence.Repositories;

public class InstalledEnvironmentRepository(SupportDbContext context) : RepositoryBase<InstalledEnvironment>(context)
{
    
}