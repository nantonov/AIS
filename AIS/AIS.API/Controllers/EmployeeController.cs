using AIS.API.ViewModels;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.API.Infrastructure;

namespace AIS.API.Controllers
{
    [Controller]
    [Route(EndpointConstants.ControllerEndpointRoute)]
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGenericService<Employee> _service;

        public EmployeeController(IMapper mapper, IGenericService<Employee> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeViewModel>> GetAll(CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<EmployeeViewModel>>(await _service.Get(ct));
        }

        [HttpPost(EndpointConstants.AddEndpoitRoute)]
        public async Task<EmployeeViewModel> Add([FromBody] EmployeeViewModel viewModel, CancellationToken ct)
        {
            return 
                _mapper.Map<EmployeeViewModel>(
                    await _service.Add(
                    _mapper.Map<Employee>(viewModel), ct
                    )
                );
        }

        [HttpDelete(EndpointConstants.DeleteEndpoitRoute)]
        public async Task Delete([FromBody] EmployeeViewModel viewModel, CancellationToken ct)
        {
            await _service.Delete(_mapper.Map<Employee>(viewModel), ct);
        }

        [HttpPut(EndpointConstants.UpdateEndpoitRoute)]
        public async Task<EmployeeViewModel> Update([FromBody] EmployeeViewModel viewModel, CancellationToken ct)
        {
            return 
                _mapper.Map<EmployeeViewModel>(
                    await _service.Put(
                    _mapper.Map<Employee>(viewModel), ct
                    )
                );
        }
    }
}
