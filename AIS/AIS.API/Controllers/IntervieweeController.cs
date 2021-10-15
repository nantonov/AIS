using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.API.Infrastructure;
using AIS.API.ViewModels;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AIS.API.Controllers
{
    [Route(EndpointConstants.ControllerEndpointRoute)]
    [ApiController]
    public class IntervieweeController : ControllerBase
    {
        private readonly IIntervieweeService _intervieweeService;
        private readonly IMapper _mapper;
        public IntervieweeController(IIntervieweeService intervieweeService, IMapper mapper)
        {
            this._intervieweeService = intervieweeService;
            _mapper = mapper;
        }
    
        [HttpGet(EndpointConstants.IdTemplate)]
        public async Task<IntervieweeViewModel> GetInterviewee(int id)
        {
            var interviewee = _mapper.Map<Interviewee, IntervieweeViewModel>(await _intervieweeService.GetById(id, new CancellationToken()));
            return interviewee;
        }
    
        [HttpGet]
        public async Task<IEnumerable<IntervieweeViewModel>> GetInterviewees()
        {
            var interviewees = await _intervieweeService.Get(new CancellationToken());
            return _mapper.Map<IEnumerable<IntervieweeViewModel>>(interviewees);
        }
    
        [HttpPost]
        public async Task<IntervieweeViewModel> Post(IntervieweeViewModel interviewee)
        {
            return _mapper.Map<IntervieweeViewModel>(
                await _intervieweeService.Add(_mapper.Map<Interviewee>(interviewee), new CancellationToken())
                );
        }
    
        [HttpPut]
        public async Task<IntervieweeViewModel> Put(IntervieweeViewModel interviewee)
        {
            return _mapper.Map<IntervieweeViewModel>(
                await _intervieweeService.Put(_mapper.Map<Interviewee>(interviewee), new CancellationToken())
            );
        }
    
        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task Delete(int id)
        {
            return _intervieweeService.Delete(id, new CancellationToken());
        }
    
    }
}
