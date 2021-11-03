using AIS.API.Infrastructure;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.API.ViewModels.TrueAnswer;

namespace AIS.API.Controllers
{
    [Route(EndpointConstants.ControllerEndpointRoute)]
    [ApiController]
    public class TrueAnswersController : ControllerBase
    {
        private readonly IGenericService<TrueAnswer> _trueAnswerService;
        private readonly IMapper _mapper;

        public TrueAnswersController(IGenericService<TrueAnswer> trueAnswerService, IMapper mapper)
        {
            _trueAnswerService = trueAnswerService;
            _mapper = mapper;
        }

        [HttpGet(EndpointConstants.IdTemplate)]
        public async Task<TrueAnswerViewModel> GetTrueAnswer(int id, CancellationToken ct)
        {
            var trueAnswer = _mapper.Map<TrueAnswerViewModel>(await _trueAnswerService.GetById(id, ct));
            return trueAnswer;
        }

        [HttpGet]
        public async Task<IEnumerable<ShortTrueAnswerViewModel>> GetTrueAnswers(CancellationToken ct)
        {
            var trueAnswers = await _trueAnswerService.Get(ct);
            return _mapper.Map<IEnumerable<ShortTrueAnswerViewModel>>(trueAnswers);
        }

        [HttpPost]
        public async Task<TrueAnswerViewModel> AddTrueAnswer(TrueAnswerAddViewModel trueAnswer, CancellationToken ct)
        {
            return _mapper.Map<TrueAnswerViewModel>(
                await _trueAnswerService.Add(_mapper.Map<TrueAnswer>(trueAnswer), ct)
            );
        }

        [HttpPut]
        public async Task<TrueAnswerViewModel> UpdateTrueAnswer(int id, TrueAnswerUpdateViewModel trueAnswer, CancellationToken ct)
        {
            var inputModel = _mapper.Map<TrueAnswer>(trueAnswer);
            inputModel.Id = id;
            return _mapper.Map<TrueAnswerViewModel>(
                await _trueAnswerService.Put(inputModel, ct)
            );
        }

        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task DeleteTrueAnswer(int id, CancellationToken ct)
        {
            return _trueAnswerService.Delete(id, ct);
        }
    }
}
