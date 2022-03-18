using AIS.BLL.Models;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.BLL.Interfaces.Services
{
    public interface IQuestionSetService : IGenericService<QuestionSet>
    {
        new Task<QuestionSet> Add(QuestionSet entity, CancellationToken ct);
    }
}
