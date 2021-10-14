using AIS.API.ViewModels;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIS.API.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGenericService<EmployeeDto> _service;

        public EmployeeController(IMapper mapper, IGenericService<EmployeeDto> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<EmployeeModel>>(await _service.Get());
        }

        [HttpPost]
        [Route("add")]
        public async Task<EmployeeModel> Add([FromBody] EmployeeModel model)
        {
            return _mapper.Map<EmployeeModel>(await _service.Add(_mapper.Map<EmployeeDto>(model)));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task Delete([FromBody] EmployeeModel model)
        {
            await _service.Delete(_mapper.Map<EmployeeDto>(model));
        }

        [HttpPut]
        [Route("update")]
        public async Task<EmployeeModel> Update([FromBody] EmployeeModel model)
        {
            return _mapper.Map<EmployeeModel>(await _service.Put(_mapper.Map<EmployeeDto>(model)));
        }
    }
}
