using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.API.ViewModels;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AIS.API.Controllers
{
    public class IntervieweeController
    {
        [Route("api/Employee")]
        [ApiController]
        public class EmployeesController : ControllerBase
        {
            private readonly IIntervieweeService _intervieweeService;
            private readonly IMapper _mapper;
            public EmployeesController(IIntervieweeService intervieweeService, IMapper mapper)
            {
                this._intervieweeService = intervieweeService;
                _mapper = mapper;
            }

            // GET: api/<EmployeesController>
            [HttpGet("{id}")]
            public async Task<IntervieweeViewModel> GetEmployee(int id)
            {
                var employee = _mapper.Map<Interviewee, IntervieweeViewModel>(await _intervieweeService.GetById(id, new CancellationToken()));
                return employee;
            }

            // GET api/<EmployeesController>/5
            [HttpGet]
            public async Task<IEnumerable<IntervieweeViewModel>> GetEmployees()
            {
                var employees = await _intervieweeService.Get(new CancellationToken());
                return _mapper.Map<IEnumerable<IntervieweeViewModel>>(employees);
            }

            // POST api/<EmployeesController>
            [HttpPost]
            public async Task<IntervieweeViewModel> Post(IntervieweeViewModel employee)
            {
                return _mapper.Map<IntervieweeViewModel>(
                    await _intervieweeService.Add(_mapper.Map<Interviewee>(employee), new CancellationToken())
                    );
            }

            // PUT api/<EmployeesController>
            [HttpPut]
            public async Task<IntervieweeViewModel> Put(IntervieweeViewModel employee)
            {
                return _mapper.Map<IntervieweeViewModel>(
                    await _intervieweeService.Put(_mapper.Map<Interviewee>(employee), new CancellationToken())
                );
            }

            // DELETE api/<EmployeesController>/5
            [HttpDelete("{id}")]
            public Task Delete(int id)
            {
                return _intervieweeService.Delete(id, new CancellationToken());
            }
        }
    }
}
