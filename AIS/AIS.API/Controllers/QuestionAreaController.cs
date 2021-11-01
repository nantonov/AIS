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
    [Route(EndpointConstants.ControllerEndpointRoute)]
    [ApiController]
    public class QuestionAreaController : ControllerBase
    {
        private readonly IGenericService<QuestionArea> _questionAreaService;
        private readonly IMapper _mapper;

        public QuestionAreaController(IGenericService<QuestionArea> questionAreaService, IMapper mapper)
        {
            _questionAreaService = questionAreaService;
            _mapper = mapper;
        }

        [HttpGet(EndpointConstants.IdTemplate)]
        public async Task<QuestionAreaViewModel> GetQuestionArea(int id, CancellationToken ct)
        {
            var questionArea = _mapper.Map<QuestionArea, QuestionAreaViewModel>(await _questionAreaService.GetById(id, ct));
            return questionArea;
        }

        [HttpGet]
        public async Task<IEnumerable<QuestionAreaViewModel>> GetQuestionAreas(CancellationToken ct)
        {
            var questionAreas = await _questionAreaService.Get(ct);
            return _mapper.Map<IEnumerable<QuestionAreaViewModel>>(questionAreas);
        }

        [HttpPost]
        public async Task<QuestionAreaViewModel> AddQuestionArea(QuestionAreaAddViewModel questionArea, CancellationToken ct)
        {
            return _mapper.Map<QuestionAreaViewModel>(
                await _questionAreaService.Add(_mapper.Map<QuestionArea>(questionArea), ct)
            );
        }

        [HttpPut]
        public async Task<QuestionAreaViewModel> UpdateQuestionArea(QuestionAreaViewModel questionArea, CancellationToken ct)
        {
            return _mapper.Map<QuestionAreaViewModel>(
                await _questionAreaService.Put(_mapper.Map<QuestionArea>(questionArea), ct)
            );
        }

        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task DeleteQuestionArea(int id, CancellationToken ct)
        {
            return _questionAreaService.Delete(id, ct);
        }
    }
}
