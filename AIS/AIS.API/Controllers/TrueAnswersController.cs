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
    public class TrueAnswersController : ControllerBase
    {
        private readonly IGenericService<TrueAnswer> _trueAnswerService;
        private readonly IMapper _mapper;

        public TrueAnswersController(IGenericService<TrueAnswer> trueAnswerService, IMapper mapper)
        {
            this._trueAnswerService = trueAnswerService;
            this._mapper = mapper;
        }

        [HttpGet(EndpointConstants.IdTemplate)]
        public async Task<TrueAnswerViewModel> GetTrueAnswer(int id, CancellationToken ct)
        {
            var TrueAnswer = _mapper.Map<TrueAnswer, TrueAnswerViewModel>(await _trueAnswerService.GetById(id, ct));
            return TrueAnswer;
        }

        [HttpGet]
        public async Task<IEnumerable<TrueAnswerViewModel>> GetTrueAnswers(CancellationToken ct)
        {
            var TrueAnswers = await _trueAnswerService.Get(ct);
            return _mapper.Map<IEnumerable<TrueAnswerViewModel>>(TrueAnswers);
        }

        [HttpPost]
        public async Task<TrueAnswerViewModel> AddTrueAnswer(TrueAnswerViewModel TrueAnswer, CancellationToken ct)
        {
            return _mapper.Map<TrueAnswerViewModel>(
                await _trueAnswerService.Add(_mapper.Map<TrueAnswer>(TrueAnswer), ct)
                );
        }

        [HttpPut]
        public async Task<TrueAnswerViewModel> UpdateTrueAnswer(TrueAnswerViewModel TrueAnswer, CancellationToken ct)
        {
            return _mapper.Map<TrueAnswerViewModel>(
                await _trueAnswerService.Put(_mapper.Map<TrueAnswer>(TrueAnswer), ct)
            );
        }

        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task DeleteTrueAnswer(int id, CancellationToken ct)
        {
            return _trueAnswerService.Delete(id, ct);
        }
    }
}
