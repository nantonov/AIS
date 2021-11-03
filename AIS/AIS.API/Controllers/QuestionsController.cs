using AIS.API.Infrastructure;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.API.ViewModels.Question;

namespace AIS.API.Controllers
{
    [Route(EndpointConstants.ControllerEndpointRoute)]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IGenericService<Question> _questionService;
        private readonly IMapper _mapper;

        public QuestionsController(IGenericService<Question> questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        [HttpGet(EndpointConstants.IdTemplate)]
        public async Task<QuestionViewModel> GetQuestion(int id, CancellationToken ct)
        {
            var question = _mapper.Map<QuestionViewModel>(await _questionService.GetById(id, ct));
            return question;
        }

        [HttpGet]
        public async Task<IEnumerable<ShortQuestionViewModel>> GetQuestions(CancellationToken ct)
        {
            var questions = await _questionService.Get(ct);
            return _mapper.Map<IEnumerable<ShortQuestionViewModel>>(questions);
        }

        [HttpPost]
        public async Task<QuestionViewModel> AddQuestion(QuestionAddViewModel question, CancellationToken ct)
        {
            return _mapper.Map<QuestionViewModel>(
                await _questionService.Add(_mapper.Map<Question>(question), ct)
            );
        }

        [HttpPut]
        public async Task<QuestionViewModel> UpdateQuestion(int id, QuestionUpdateViewModel question, CancellationToken ct)
        {
            var inputModel = _mapper.Map<Question>(question);
            inputModel.Id = id;
            return _mapper.Map<QuestionViewModel>(
                await _questionService.Put(inputModel, ct)
            );
        }

        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task DeleteQuestion(int id, CancellationToken ct)
        {
            return _questionService.Delete(id, ct);
        }
    }
}
