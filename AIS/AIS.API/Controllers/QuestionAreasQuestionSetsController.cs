using AIS.API.Infrastructure;
using AIS.API.ViewModels.QuestionAreasQuestionSets;
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
    public class QuestionAreasQuestionSetsController : ControllerBase
    {
        private readonly IQuestionAreasQuestionSetsService _questionAreasQuestionSetsService;
        private readonly IMapper _mapper;
        private readonly IValidator<ChangeQuestionAreasQuestionSetsViewModel> _validator;
        public QuestionAreasQuestionSetsController(IQuestionAreasQuestionSetsService questionAreasQuestionSetsService, IMapper mapper, IValidator<ChangeQuestionAreasQuestionSetsViewModel> validator)
        {
            _questionAreasQuestionSetsService = questionAreasQuestionSetsService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet(EndpointConstants.IdTemplate)]
        public async Task<QuestionAreasQuestionSetsViewModel> GetById(int id, CancellationToken ct)
        {
            var questionAreasQuestionSets = _mapper.Map<QuestionAreasQuestionSetsViewModel>(await _questionAreasQuestionSetsService.GetById(id, ct));
            return questionAreasQuestionSets;
        }

        [HttpGet]
        public async Task<IEnumerable<ShortQuestionAreasQuestionSetsViewModel>> GetAll(CancellationToken ct)
        {
            var questionAreasQuestionSets = await _questionAreasQuestionSetsService.Get(ct);
            return _mapper.Map<IEnumerable<ShortQuestionAreasQuestionSetsViewModel>>(questionAreasQuestionSets);
        }

        [HttpPost]
        public async Task<QuestionAreasQuestionSetsViewModel> Post(ChangeQuestionAreasQuestionSetsViewModel questionAreasQuestionSets, CancellationToken ct)
        {
            _validator.Validate(questionAreasQuestionSets);
            return _mapper.Map<QuestionAreasQuestionSetsViewModel>(
                await _questionAreasQuestionSetsService.Add(_mapper.Map<QuestionAreasQuestionSets>(questionAreasQuestionSets), ct)
                );
        }

        [HttpPut]
        public async Task<QuestionAreasQuestionSetsViewModel> Put(ChangeQuestionAreasQuestionSetsViewModel questionAreasQuestionSets, int id, CancellationToken ct)
        {
            _validator.Validate(questionAreasQuestionSets);
            var entity = _mapper.Map<QuestionAreasQuestionSets>(questionAreasQuestionSets);
            entity.Id = id;

            return _mapper.Map<QuestionAreasQuestionSetsViewModel>(
                await _questionAreasQuestionSetsService.Put(entity, ct)
            );
        }

        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task Delete(int id, CancellationToken ct)
        {
            return _questionAreasQuestionSetsService.Delete(id, ct);
        }

        [HttpDelete(EndpointConstants.DeleteByTwoIds)]
        public Task Delete(int questionAreaId, int questionSetId, CancellationToken ct)
        {
            return _questionAreasQuestionSetsService.Delete(questionAreaId, questionSetId, ct);
        }
    }
}
