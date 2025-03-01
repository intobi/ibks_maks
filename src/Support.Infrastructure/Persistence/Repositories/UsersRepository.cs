using Support.Domain.Entities;
using Support.Infrastructure.Persistence.DbContext;

namespace Support.Infrastructure.Persistence.Repositories;

public class UsersRepository(SupportDbContext context) : RepositoryBase<User>(context)
{
    
}