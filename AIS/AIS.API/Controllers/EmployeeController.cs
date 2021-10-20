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
        private readonly IValidator<ChangeEmployeeViewModel> _changeEmployeeValidator;

        public EmployeeController(
                         IMapper mapper,
                         IGenericService<Employee> service,
                         IValidator<ChangeEmployeeViewModel> changeEmployeeValidator)
        {
            _mapper = mapper;
            _service = service;
            _changeEmployeeValidator = changeEmployeeValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeViewModel>> GetAll(CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<EmployeeViewModel>>(await _service.Get(ct));
        }

        [HttpPost(EndpointConstants.AddEndpoitRoute)]
        public async Task<EmployeeViewModel> Add([FromBody] ChangeEmployeeViewModel viewModel, CancellationToken ct)
        {
            await _changeEmployeeValidator.ValidateAndThrowAsync(viewModel, ct);

            return
                _mapper.Map<EmployeeViewModel>(
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
        public async Task<EmployeeViewModel> Update([FromBody] ChangeEmployeeViewModel viewModel, int id, CancellationToken ct)
        {
            await _changeEmployeeValidator.ValidateAndThrowAsync(viewModel, ct);

            var mappedModel = _mapper.Map<Employee>(viewModel);
            mappedModel.Id = id;

            return
                _mapper.Map<EmployeeViewModel>(
                    await _service.Put(mappedModel, ct)
                );
        }
    }
}