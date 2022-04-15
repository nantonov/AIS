using AIS.API.Infrastructure;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.API.ViewModels.QuestionArea;
using Microsoft.AspNetCore.Authorization;

namespace AIS.API.Controllers
{
    [Route(EndpointConstants.ControllerEndpointRoute)]
    [ApiController]
    public class QuestionAreaController : ControllerBase
    {
        private readonly IQuestionAreaService _questionAreaService;
        private readonly IMapper _mapper;

        public QuestionAreaController(IQuestionAreaService questionAreaService, IMapper mapper)
        {
            _questionAreaService = questionAreaService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet(EndpointConstants.IdTemplate)]
        public async Task<QuestionAreaViewModel> GetQuestionArea(int id, CancellationToken ct)
        {
            var questionArea = _mapper.Map<QuestionAreaViewModel>(await _questionAreaService.GetById(id, ct));
            return questionArea;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<ShortQuestionAreaViewModel>> GetQuestionAreas(CancellationToken ct)
        {
            var questionAreas = await _questionAreaService.Get(ct);
            var res = _mapper.Map<IEnumerable<ShortQuestionAreaViewModel>>(questionAreas);

            return res;
        }

        [HttpPost]
        public async Task<QuestionAreaViewModel> AddQuestionArea(QuestionAreaAddViewModel questionArea, CancellationToken ct)
        {
            return _mapper.Map<QuestionAreaViewModel>(
                await _questionAreaService.Add(_mapper.Map<QuestionArea>(questionArea), ct)
            );
        }

        [HttpPut]
        public async Task<QuestionAreaViewModel> UpdateQuestionArea(int id, QuestionAreaUpdateViewModel questionArea, CancellationToken ct)
        {
            var inputModel = _mapper.Map<QuestionArea>(questionArea);
            inputModel.Id = id;
            return _mapper.Map<QuestionAreaViewModel>(
                await _questionAreaService.Put(inputModel, ct)
            );
        }

        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task DeleteQuestionArea(int id, CancellationToken ct)
        {
            return _questionAreaService.Delete(id, ct);
        }
    }
}
