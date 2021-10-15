using System.Threading;
using System.Threading.Tasks;
using AIS.DAL.Entities;

namespace AIS.DAL.Interfaces.Repositories
{
    public interface IIntervieweeRepository : IGenericRepository<IntervieweeEntity>
    {
        Task Delete(int id, CancellationToken ct);
    }
}
