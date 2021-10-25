using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.BLL.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _repository;
        private readonly IMapper _mapper;

        public SessionService(ISessionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Session> Add(Session entity, CancellationToken ct)
        {
            var mappedObject = _mapper.Map<SessionEntity>(entity);
            return _mapper.Map<Session>(await _repository.Add(mappedObject, ct));
        }

        public async Task<IEnumerable<Session>> Get(CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<Session>>(await _repository.Get(ct));
        }

        public async Task<Session> GetById(int id, CancellationToken ct)
        {
            return _mapper.Map<Session>(await _repository.GetById(id, ct));
        }

        public async Task<Session> Put(Session entity, CancellationToken ct)
        {
            var mappedObject = _mapper.Map<SessionEntity>(entity);
            return _mapper.Map<Session>(await _repository.Put(mappedObject, ct));
        }

        public async Task<bool> Delete(int id, CancellationToken ct)
        {
            var entity = await _repository.GetById(id, ct);
            if (entity is null)
            {
                return false;
            }
            return await _repository.Delete(entity, ct);
        }
    }
}