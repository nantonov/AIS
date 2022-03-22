using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.BLL.Services
{
    public class QuestionSetService : GenericService<QuestionSet, QuestionSetEntity>, IQuestionSetService
    {
        private readonly IQuestionSetRepository _questionSetRepository;
        private readonly IQuestionAreasQuestionSetsRepository _questionAreasQuestionSetsRepository;
        private readonly IQuestionsQuestionSetsRepository _questionsQuestionSetsRepository;
        private readonly IMapper _mapper;
        public QuestionSetService(IQuestionSetRepository repository, IQuestionAreasQuestionSetsRepository questionAreasQuestionSetsRepository,
            IQuestionsQuestionSetsRepository questionsQuestionSetsRepository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
            _questionSetRepository = repository;
            _questionAreasQuestionSetsRepository = questionAreasQuestionSetsRepository;
            _questionsQuestionSetsRepository = questionsQuestionSetsRepository;
        }

        public override async Task<QuestionSet> Add(QuestionSet entity, CancellationToken ct)
        {
            var questionAreaIds = entity.QuestionAreaIds?.ToList();
            var questionIds = entity.QuestionIds?.ToList();
            var res = await _questionSetRepository.Add(_mapper.Map<QuestionSetEntity>(entity), ct);

            if (questionIds is not null)
            {
                var questionsList = questionIds.Select(id => new QuestionsQuestionSetsEntity { QuestionId = id, QuestionSetId = res.Id }).ToList();
                await _questionsQuestionSetsRepository.AddRange(questionsList.ToList(), ct);
            }

            if (questionAreaIds is not null)
            {
                var areasList = questionAreaIds.Select(id => new QuestionAreasQuestionSetsEntity { QuestionAreaId = id, QuestionSetId = res.Id }).ToList();
                await _questionAreasQuestionSetsRepository.AddRange(areasList, ct);
            }

            return _mapper.Map<QuestionSet>(res);
        }
    }
}
