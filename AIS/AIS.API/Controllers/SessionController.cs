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
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public SessionController(ISessionService sessionService, IMapper mapper)
        {
            _sessionService = sessionService;
            _mapper = mapper;
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
            var result = await _sessionService.Add(mappedObject, ct);
            return _mapper.Map<SessionViewModel>(result);
        }

        [HttpPut(EndpointConstants.UpdateEndpoitRoute)]
        public async Task<SessionViewModel> Put([FromQuery]int id, [FromBody] SessionUpdateViewModel session, CancellationToken ct)
        {
            var mappedObject = _mapper.Map<Session>(session);
            mappedObject.Id = id;
            return _mapper.Map<SessionViewModel>(await _sessionService.Put(mappedObject, ct));
        }

        [HttpDelete(EndpointConstants.IdTemplate)]
        public async Task Delete(int id, CancellationToken ct)
        {
            await _sessionService.Delete(id, ct);
        }
    }
}