using AIS.API.Infrastructure;
using AIS.API.ViewModels.QuestionIntervieweeAnswer;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.API.Controllers
{
    [ApiController]
    [Route(EndpointConstants.ControllerEndpointRoute)]
    public class QuestionIntervieweeAnswerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGenericService<QuestionIntervieweeAnswer> _service;

        public QuestionIntervieweeAnswerController(
                        IGenericService<QuestionIntervieweeAnswer> companyService,
                        IMapper mapper)
        {
            _service = companyService;
            _mapper = mapper;
        }

        [HttpGet(EndpointConstants.IdTemplate)]
        public async Task<QuestionIntervieweeAnswerViewModel> GetById(int id, CancellationToken ct)
        {
            var company = _mapper.Map<QuestionIntervieweeAnswerViewModel>(await _service.GetById(id, ct));
            return company;
        }

        [HttpGet]
        public async Task<IEnumerable<ShortQuestionIntervieweeAnswerViewModel>> GetAll(CancellationToken ct)
        {
            var companies = await _service.Get(ct);
            return _mapper.Map<IEnumerable<ShortQuestionIntervieweeAnswerViewModel>>(companies);
        }

        [HttpPost]
        public async Task<QuestionIntervieweeAnswerAddViewModel> Add(QuestionIntervieweeAnswerAddViewModel company, CancellationToken ct)
        {
            return _mapper.Map<QuestionIntervieweeAnswerAddViewModel>(
                await _service.Add(_mapper.Map<QuestionIntervieweeAnswer>(company), ct)
                );
        }

        [HttpPut]
        public async Task<QuestionIntervieweeAnswerViewModel> Update(QuestionIntervieweeAnswerUpdateViewModel company, int id, CancellationToken ct)
        {
            var entity = _mapper.Map<QuestionIntervieweeAnswer>(company);
            entity.Id = id;

            return _mapper.Map<QuestionIntervieweeAnswerViewModel>(
                await _service.Put(entity, ct)
            );
        }

        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task Delete(int id, CancellationToken ct)
        {
            return _service.Delete(id, ct);
        }
    }
}
