using AIS.API.ViewModels.Employee;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.API.Infrastructure;
using FluentValidation;

namespace AIS.API.Controllers
{
    [Controller]
    [Route(EndpointConstants.ControllerEndpointRoute)]
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGenericService<Employee> _service;
        private readonly IValidator<EmployeeViewModel> _employeeValidator;
        private readonly IValidator<AddEmployeeViewModel> _addEmployeeValidator;

        public EmployeeController(
                         IMapper mapper, 
                         IGenericService<Employee> service,
                         IValidator<EmployeeViewModel> employeeValidator,
                         IValidator<AddEmployeeViewModel> addEmployeeValidator)
        {
            this._mapper = mapper;
            this._service = service;
            this._employeeValidator = employeeValidator;
            this._addEmployeeValidator = addEmployeeValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeViewModel>> GetAll(CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<EmployeeViewModel>>(await _service.Get(ct));
        }

        [HttpPost(EndpointConstants.AddEndpoitRoute)]
        public async Task<AddEmployeeViewModel> Add([FromBody] AddEmployeeViewModel viewModel, CancellationToken ct)
        {
            await _addEmployeeValidator.ValidateAndThrowAsync(viewModel);

            return 
                _mapper.Map<AddEmployeeViewModel>(
                    await _service.Add(
                    _mapper.Map<Employee>(viewModel), ct
                    )
                );
        }

        [HttpDelete(EndpointConstants.DeleteEndpoitRoute)]
        public async Task Delete(int id, CancellationToken ct)
        {
            await _service.Delete(id, ct);
        }

        [HttpPut(EndpointConstants.UpdateEndpoitRoute)]
        public async Task<EmployeeViewModel> Update([FromBody] EmployeeViewModel viewModel, CancellationToken ct)
        {
            await _employeeValidator.ValidateAndThrowAsync(viewModel);

            return 
                _mapper.Map<EmployeeViewModel>(
                    await _service.Put(
                    _mapper.Map<Employee>(viewModel), ct
                    )
                );
        }
    }
}
