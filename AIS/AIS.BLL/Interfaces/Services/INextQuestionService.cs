using AIS.BLL.Models;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.BLL.Interfaces.Services
{
    public interface INextQuestionService
    {
        Task<Question> next(int sessionId, int setId, CancellationToken ct);
    }
}
