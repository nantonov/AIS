using AIS.DAL.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.DAL.Interfaces.Repositories
{
    public interface ISessionRepository
    {
        Task<SessionEntity> Add(SessionEntity entity, CancellationToken ct);
        Task<IEnumerable<SessionEntity>> Get(CancellationToken ct);
        Task<SessionEntity> GetById(int id, CancellationToken ct);
        Task<SessionEntity> Put(SessionEntity entity, CancellationToken ct);
        Task<bool> Delete(SessionEntity entity, CancellationToken ct);
    }
}