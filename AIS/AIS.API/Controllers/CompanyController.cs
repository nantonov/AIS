using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.API.Infrastructure;
using AIS.API.ViewModels.Company;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AIS.API.Controllers
{
    [Route(EndpointConstants.ControllerEndpointRoute)]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IGenericService<Company> _companyService;
        private readonly IMapper _mapper;

        public CompanyController(IGenericService<Company> companyService, IMapper mapper)
        {
            this._companyService = companyService;
            this._mapper = mapper;
        }
    
        [HttpGet(EndpointConstants.IdTemplate)]
        public async Task<CompanyViewModel> GetCompany(int id, CancellationToken ct)
        {
            var company = _mapper.Map<Company, CompanyViewModel>(await _companyService.GetById(id, ct));
            return company;
        }
    
        [HttpGet]
        public async Task<IEnumerable<CompanyViewModel>> GetCompanies(CancellationToken ct)
        {
            var companies = await _companyService.Get(ct);
            return _mapper.Map<IEnumerable<CompanyViewModel>>(companies);
        }
    
        [HttpPost]
        public async Task<CompanyViewModel> Post(ChangeCompanyViewModel company, CancellationToken ct)
        {
            return _mapper.Map<CompanyViewModel>(
                await _companyService.Add(_mapper.Map<Company>(company), ct)
                );
        }
    
        [HttpPut]
        public async Task<CompanyViewModel> Put(ChangeCompanyViewModel company, int id, CancellationToken ct)
        {
            var entity = _mapper.Map<Company>(company);
            entity.Id = id;

            return _mapper.Map<CompanyViewModel>(
                await _companyService.Put(entity, ct)
            );
        }
    
        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task Delete(int id, CancellationToken ct)
        {
            return _companyService.Delete(id, ct);
        }
    }
}
