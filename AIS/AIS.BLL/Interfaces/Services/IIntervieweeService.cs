using System.Threading;
using System.Threading.Tasks;
using AIS.BLL.Models;

namespace AIS.BLL.Interfaces.Services
{
    public interface IIntervieweeService : IGenericService<Interviewee>
    {
        Task Delete(int id, CancellationToken ct);
    }
}
