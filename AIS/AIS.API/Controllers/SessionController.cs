using AIS.API.Infrastructure;
using AIS.API.ViewModels;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.API.Controllers
{
    [Route(EndpointConstants.ControllerEndpointRoute)]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IGenericService<Session> _sessionService;
        private readonly IMapper _mapper;

        public SessionController(IGenericService<Session> sessionService, IMapper mapper)
        {
            this._sessionService = sessionService;
            this._mapper = mapper;
        }

        [HttpGet(EndpointConstants.IdTemplate)]
        public async Task<SessionViewModel> GetSession(int id, CancellationToken ct)
        {
            var session = _mapper.Map<SessionViewModel>(await _sessionService.GetById(id, ct));
            return session;
        }

        [HttpGet]
        public async Task<IEnumerable<SessionViewModel>> GetSessions(CancellationToken ct)
        {
            var sessions = await _sessionService.Get(ct);
            return _mapper.Map<IEnumerable<SessionViewModel>>(sessions);
        }

        [HttpPost]
        public async Task<SessionViewModel> Post(SessionAddViewModel session, CancellationToken ct)
        {
            var mappedObject = _mapper.Map<Session>(session);
            return _mapper.Map<SessionViewModel>(await _sessionService.Add(mappedObject, ct));
        }

        [HttpPut]
        public async Task<SessionViewModel> Put(SessionUpdateViewModel session, CancellationToken ct)
        {
            var mappedObject = _mapper.Map<Session>(session);
            return _mapper.Map<SessionViewModel>(await _sessionService.Add(mappedObject, ct));
        }

        [HttpDelete(EndpointConstants.IdTemplate)]
        public Task Delete(int id, CancellationToken ct)
        {
            return _sessionService.Delete(id, ct);
        }
    }
}