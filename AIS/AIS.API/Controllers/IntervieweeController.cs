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
        private readonly IGenericService<Interviewee> _intervieweeService;
        private readonly IMapper _mapper;
        public IntervieweeController(IGenericService<Interviewee> intervieweeService, IMapper mapper)
        {
            this._intervieweeService = intervieweeService;
            this._mapper = mapper;
        }
    
        [HttpGet(EndpointConstants.IdTemplate)]
        public async Task<IntervieweeViewModel> GetInterviewee(int id, CancellationToken ct)
        {
            var interviewee = _mapper.Map<Interviewee, IntervieweeViewModel>(await _intervieweeService.GetById(id, ct));
            return interviewee;
        }
    
        [HttpGet]
        public async Task<IEnumerable<IntervieweeViewModel>> GetInterviewees(CancellationToken ct)
        {
            var interviewees = await _intervieweeService.Get(ct);
            return _mapper.Map<IEnumerable<IntervieweeViewModel>>(interviewees);
        }
    
        [HttpPost]
        public async Task<IntervieweeViewModel> Post(IntervieweeViewModel interviewee, CancellationToken ct)
        {
            return _mapper.Map<IntervieweeViewModel>(
                await _intervieweeService.Add(_mapper.Map<Interviewee>(interviewee), ct)
                );
        }
    
        [HttpPut]
        public async Task<IntervieweeViewModel> Put(IntervieweeViewModel interviewee, CancellationToken ct)
        {
            return _mapper.Map<IntervieweeViewModel>(
                await _intervieweeService.Put(_mapper.Map<Interviewee>(interviewee), ct)
            );
        }
    
        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task Delete(int id, CancellationToken ct)
        {
            return _intervieweeService.Delete(id, ct);
        }
    
    }
}
