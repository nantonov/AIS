using AIS.API.ViewModels;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet()]
        [HttpGet(EndpointConstants.GetEndpoitRoute)]
        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<EmployeeViewModel>>(await _service.Get());
        }

        [HttpPost(EndpointConstants.AddEndpoitRoute)]
        public async Task<EmployeeViewModel> Add([FromBody] EmployeeViewModel viewModel)
        {
            return 
                _mapper.Map<EmployeeViewModel>(
                    await _service.Add(
                    _mapper.Map<Employee>(viewModel)
                    )
                );
        }

        [HttpDelete(EndpointConstants.DeleteEndpoitRoute)]
        public async Task Delete([FromBody] EmployeeViewModel viewModel)
        {
            await _service.Delete(_mapper.Map<Employee>(viewModel));
        }

        [HttpPut(EndpointConstants.UpdateEndpoitRoute)]
        public async Task<EmployeeViewModel> Update([FromBody] EmployeeViewModel viewModel)
        {
            return 
                _mapper.Map<EmployeeViewModel>(
                    await _service.Put(
                    _mapper.Map<Employee>(viewModel)
                    )
                );
        }
    }
}
