using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using System.Collections.Generic;
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
            var questionAreaIds = ConvertToList(entity);
            var questionIds = ConvertToList(entity);
            var res = await _questionSetRepository.Add(_mapper.Map<QuestionSetEntity>(entity), ct);
            questionAreaIds.ForEach(x => _questionAreasQuestionSetsRepository.Add(
                new QuestionAreasQuestionSetsEntity{
                    QuestionAreaId = x, 
                    QuestionSetId=res.Id
                }, ct));
            questionIds.ForEach(x => _questionsQuestionSetsRepository.Add(
                new QuestionsQuestionSetsEntity
            {
                QuestionSetId = res.Id,
                QuestionId = x
            }, ct));

            return _mapper.Map<QuestionSet>(res);
        }

        private static List<int> ConvertToList(QuestionSet entity)
        {
            var ids = new List<int>();
            foreach (var item in entity.QuestionIds)
            {
                ids.Add(item);
            }
            return ids;
        }
    }
}
