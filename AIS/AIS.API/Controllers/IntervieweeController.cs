using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.API.Infrastructure;
using AIS.API.ViewModels.Interviewee;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AIS.API.Controllers
{
    [Route(EndpointConstants.ControllerEndpointRoute)]
    [ApiController]
    public class IntervieweeController : ControllerBase
    {
        private readonly IGenericService<Interviewee> _intervieweeService;
        private readonly IMapper _mapper;
        private readonly IValidator<ChangeIntervieweeViewModel> _validator;

        public IntervieweeController(
                    IGenericService<Interviewee> intervieweeService, 
                    IMapper mapper, 
                    IValidator<ChangeIntervieweeViewModel> validator)
        {
            _intervieweeService = intervieweeService;
            _mapper = mapper;
            _validator = validator;
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
        public async Task<IntervieweeViewModel> Post(ChangeIntervieweeViewModel interviewee, CancellationToken ct)
        {
            await _validator.ValidateAndThrowAsync(interviewee, ct);

            return _mapper.Map<IntervieweeViewModel>(
                await _intervieweeService.Add(_mapper.Map<Interviewee>(interviewee), ct)
                );
        }
    
        [HttpPut]
        public async Task<IntervieweeViewModel> Put(ChangeIntervieweeViewModel interviewee, int id, CancellationToken ct)
        {
            await _validator.ValidateAndThrowAsync(interviewee, ct);

            var entity = _mapper.Map<Interviewee>(interviewee);
            entity.Id = id;

            return _mapper.Map<IntervieweeViewModel>(
                    await _intervieweeService.Put(entity, ct)
                );
        }
    
        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task Delete(int id, CancellationToken ct)
        {
            return _intervieweeService.Delete(id, ct);
        }
    
    }
}
