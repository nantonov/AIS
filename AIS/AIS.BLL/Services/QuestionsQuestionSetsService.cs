using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.BLL.Services
{
    public class QuestionsQuestionSetsService : GenericService<QuestionsQuestionSets, QuestionsQuestionSetsEntity>, IQuestionsQuestionSetsService
    {
        public IQuestionsQuestionSetsRepository _repo;
        public QuestionsQuestionSetsService(IQuestionsQuestionSetsRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repo = repository;
        }
        public async Task Delete(int questionSetId, int questionId, CancellationToken ct)
        {
            await _repo.Delete(questionSetId, questionId, ct);
        }
    }
}
