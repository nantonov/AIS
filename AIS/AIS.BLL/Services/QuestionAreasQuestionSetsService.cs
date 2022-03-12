using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.BLL.Services
{
    public class QuestionAreasQuestionSetsService : GenericService<QuestionAreasQuestionSets, QuestionAreasQuestionSetsEntity>, IQuestionAreasQuestionSetsService
    {
        private readonly IQuestionAreasQuestionSetsRepository _repo;
        public QuestionAreasQuestionSetsService(IQuestionAreasQuestionSetsRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repo = repository;
        }

        public async Task DeleteByQuestionSetIdAndQuestionAreaId(int questionAreaId, int questionSetId, CancellationToken ct)
        {
            await _repo.DeleteByQuestionAreaIdAndQuestionSetId(questionAreaId, questionSetId, ct);
        }
    }
}
