using AIS.BLL.Models;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.BLL.Interfaces.Services
{
    public interface IQuestionsQuestionSetsService: IGenericService<QuestionsQuestionSets>
    {
        Task Delete(int questionSetId, int questionId, CancellationToken ct);
    }
}
