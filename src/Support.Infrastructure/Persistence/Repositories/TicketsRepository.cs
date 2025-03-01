using Support.Domain.Entities;
using Support.Infrastructure.Persistence.DbContext;

namespace Support.Infrastructure.Persistence.Repositories;

public class TicketsRepository(SupportDbContext context) : RepositoryBase<Ticket>(context)
{
}