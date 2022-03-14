using AIS.DAL.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.DAL.Interfaces.Repositories
{
    public interface IQuestionsQuestionSetsRepository: IGenericRepository<QuestionsQuestionSetsEntity>
    {
        Task Delete(int questionSetId, int questionId, CancellationToken ct);
    }
}
