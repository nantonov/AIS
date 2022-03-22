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

        public Task Delete(int areaId, int setId, CancellationToken ct)
        {
            return _repo.Delete(areaId, setId, ct);
        }
    }
}
