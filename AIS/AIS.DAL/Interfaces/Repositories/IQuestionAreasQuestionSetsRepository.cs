using AIS.DAL.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.DAL.Interfaces.Repositories
{
    public interface IQuestionAreasQuestionSetsRepository: IGenericRepository<QuestionAreasQuestionSetsEntity>
    {
        Task Delete(int areaId, int setId, CancellationToken ct);
    }
}
