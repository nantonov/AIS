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

            var areaQuestionSetEntity = new QuestionAreasQuestionSetsEntity { QuestionSetId = res.Id };
            var questionQuestionSetEntity = new QuestionsQuestionSetsEntity { QuestionSetId = res.Id };

            if (questionAreaIds != null)
                foreach (var item in questionAreaIds)
                {
                    areaQuestionSetEntity.QuestionAreaId = item;
                    await _questionAreasQuestionSetsRepository.Add(areaQuestionSetEntity, ct);
                }

            if (questionIds != null)
                foreach (var item in questionIds)
                {
                    questionQuestionSetEntity.QuestionSetId = item;
                    await _questionsQuestionSetsRepository.Add(questionQuestionSetEntity, ct);
                }

            return _mapper.Map<QuestionSet>(res);
        }
    }
}
