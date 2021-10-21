using AIS.API.Infrastructure;
using AIS.API.ViewModels;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IGenericService<Question> _questionService;
        private readonly IMapper _mapper;

        public QuestionsController(IGenericService<Question> questionService, IMapper mapper)
        {
            this._questionService = questionService;
            this._mapper = mapper;
        }

        [HttpGet(EndpointConstants.IdTemplate)]
        public async Task<QuestionViewModel> GetQuestion(int id, CancellationToken ct)
        {
            var Question = _mapper.Map<Question, QuestionViewModel>(await _questionService.GetById(id, ct));
            return Question;
        }

        [HttpGet]
        public async Task<IEnumerable<QuestionViewModel>> GetQuestions(CancellationToken ct)
        {
            var Questions = await _questionService.Get(ct);
            return _mapper.Map<IEnumerable<QuestionViewModel>>(Questions);
        }

        [HttpPost]
        public async Task<QuestionViewModel> AddQuestion(QuestionViewModel Question, CancellationToken ct)
        {
            return _mapper.Map<QuestionViewModel>(
                await _questionService.Add(_mapper.Map<Question>(Question), ct)
                );
        }

        [HttpPut]
        public async Task<QuestionViewModel> UpdateQuestion(QuestionViewModel Question, CancellationToken ct)
        {
            return _mapper.Map<QuestionViewModel>(
                await _questionService.Put(_mapper.Map<Question>(Question), ct)
            );
        }

        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task DeleteQuestion(int id, CancellationToken ct)
        {
            return _questionService.Delete(id, ct);
        }
    }
}
