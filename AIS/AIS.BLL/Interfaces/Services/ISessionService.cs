using AIS.BLL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.BLL.Interfaces.Services
{
    public interface ISessionService
    {
        Task<Session> Add(Session entity, CancellationToken ct);
        Task<IEnumerable<Session>> Get(CancellationToken ct);
        Task<Session> GetById(int id, CancellationToken ct);
        Task<Session> Put(Session entity, CancellationToken ct);
        Task<bool> Delete(int id, CancellationToken ct);
    }
}