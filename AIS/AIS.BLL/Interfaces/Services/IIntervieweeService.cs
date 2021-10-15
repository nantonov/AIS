using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.BLL.Models;

namespace AIS.BLL.Interfaces.Services
{
    public interface IIntervieweeService
    {
        Task<Interviewee> Add(Interviewee entity, CancellationToken ct);
        Task<IEnumerable<Interviewee>> Get(CancellationToken ct);
        Task<Interviewee> GetById(int id, CancellationToken ct);
        Task<Interviewee> Put(Interviewee entity, CancellationToken ct);
        Task Delete(int id, CancellationToken ct);
    }
}
