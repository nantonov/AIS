using AIS.BLL.Models;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.BLL.Interfaces.Services
{
    public interface IQuestionAreasQuestionSetsService: IGenericService<QuestionAreasQuestionSets>
    {
        Task Delete(int areaId, int setId, CancellationToken ct);
    }
}
