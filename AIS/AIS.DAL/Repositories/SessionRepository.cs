using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;

namespace AIS.DAL.Repositories
{
    public class SessionRepository : GenericRepository<SessionEntity>, ISessionRepository
    {
        public SessionRepository(DatabaseContext context) : base(context)
        {
        }
    }
}