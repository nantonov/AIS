using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.DAL.Entities;

namespace AIS.DAL.Interfaces.Repositories
{
    public interface IIntervieweeRepository
    {
        Task<IntervieweeEntity> Add(IntervieweeEntity entity, CancellationToken ct);
        Task<IEnumerable<IntervieweeEntity>> Get(CancellationToken ct);
        Task<IntervieweeEntity> GetById(int id, CancellationToken ct);
        Task<IntervieweeEntity> Update(IntervieweeEntity entity, CancellationToken ct);
        Task Delete(int id, CancellationToken ct);
    }
}
