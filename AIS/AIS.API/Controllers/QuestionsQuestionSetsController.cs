using AIS.API.Infrastructure;
using AIS.API.ViewModels.QuestionsQuestionSets;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsQuestionSetsController : ControllerBase
    {
        private readonly IQuestionsQuestionSetsService _questionsQuestionSetsService;
        private readonly IMapper _mapper;
        private readonly IValidator<ChangeQuestionsQuestionSetsViewModel> _validator;
        public QuestionsQuestionSetsController(IQuestionsQuestionSetsService questionsQuestionSetsService, IMapper mapper, IValidator<ChangeQuestionsQuestionSetsViewModel> validator)
        {
            _questionsQuestionSetsService = questionsQuestionSetsService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet(EndpointConstants.IdTemplate)]
        public async Task<QuestionsQuestionSetsViewModel> GetById(int id, CancellationToken ct)
        {
            var questionsQuestionSets = _mapper.Map<QuestionsQuestionSetsViewModel>(await _questionsQuestionSetsService.GetById(id, ct));
            return questionsQuestionSets;
        }

        [HttpGet]
        public async Task<IEnumerable<ShortQuestionsQuestionSetsViewModel>> GetAll(CancellationToken ct)
        {
            var questionsQuestionSets = await _questionsQuestionSetsService.Get(ct);
            return _mapper.Map<IEnumerable<ShortQuestionsQuestionSetsViewModel>>(questionsQuestionSets);
        }

        [HttpPost]
        public async Task<QuestionsQuestionSetsViewModel> Post(ChangeQuestionsQuestionSetsViewModel questionsQuestionSets, CancellationToken ct)
        {
            _validator.Validate(questionsQuestionSets);
            return _mapper.Map<QuestionsQuestionSetsViewModel>(
                await _questionsQuestionSetsService.Add(_mapper.Map<QuestionsQuestionSets>(questionsQuestionSets), ct)
                );
        }

        [HttpPut]
        public async Task<QuestionsQuestionSetsViewModel> Put(ChangeQuestionsQuestionSetsViewModel questionsQuestionSets, int id, CancellationToken ct)
        {
            _validator.Validate(questionsQuestionSets);
            var entity = _mapper.Map<QuestionsQuestionSets>(questionsQuestionSets);
            entity.Id = id;

            return _mapper.Map<QuestionsQuestionSetsViewModel>(
                await _questionsQuestionSetsService.Put(entity, ct)
            );
        }

        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task Delete(int id, CancellationToken ct)
        {
            return _questionsQuestionSetsService.Delete(id, ct);
        }
        [HttpDelete(EndpointConstants.DeleteByTwoIds)]
        public async Task DeleteEndpoitRoute(int questionSetId, int questionId, CancellationToken ct)
        {
            await _questionsQuestionSetsService.Delete(questionSetId, questionId, ct);
        }
    }
}
