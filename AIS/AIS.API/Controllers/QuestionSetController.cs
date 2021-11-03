using AIS.API.Infrastructure;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.API.ViewModels.QuestionSet;

namespace AIS.API.Controllers
{
    [Route(EndpointConstants.ControllerEndpointRoute)]
    [ApiController]
    public class QuestionSetController : ControllerBase
    {
        private readonly IGenericService<QuestionSet> _questionSetService;
        private readonly IMapper _mapper;

        public QuestionSetController(IGenericService<QuestionSet> questionSetService, IMapper mapper)
        {
            _questionSetService = questionSetService;
            _mapper = mapper;
        }

        [HttpGet(EndpointConstants.IdTemplate)]
        public async Task<QuestionSetViewModel> GetQuestionSet(int id, CancellationToken ct)
        {
            var questionSet = _mapper.Map<QuestionSetViewModel>(await _questionSetService.GetById(id, ct));
            return questionSet;
        }

        [HttpGet]
        public async Task<IEnumerable<ShortQuestionSetViewModel>> GetQuestionSets(CancellationToken ct)
        {
            var questionSets = await _questionSetService.Get(ct);
            return _mapper.Map<IEnumerable<ShortQuestionSetViewModel>>(questionSets);
        }

        [HttpPost]
        public async Task<QuestionSetViewModel> AddQuestionSet(QuestionSetAddViewModel questionSet, CancellationToken ct)
        {
            return _mapper.Map<QuestionSetViewModel>(
                await _questionSetService.Add(_mapper.Map<QuestionSet>(questionSet), ct)
            );
        }

        [HttpPut]
        public async Task<QuestionSetViewModel> UpdateQuestionSet(int id, QuestionSetUpdateViewModel questionSet, CancellationToken ct)
        {
            var inputModel = _mapper.Map<QuestionSet>(questionSet);
            inputModel.Id = id;
            return _mapper.Map<QuestionSetViewModel>(
                await _questionSetService.Put(inputModel, ct)
            );
        }

        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task DeleteQuestionSet(int id, CancellationToken ct)
        {
            return _questionSetService.Delete(id, ct);
        }
    }
}
