using AIS.BLL.Models;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.BLL.Interfaces.Services
{
    public interface INextQuestionService
    {
        Task<Question> Next(int sessionId, CancellationToken ct);
    }
}
