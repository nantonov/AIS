using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.BLL.Services
{
    public class SessionService : IGenericService<Session>
    {
        private readonly IGenericRepository<SessionEntity> _repository;
        private readonly IMapper _mapper;

        public SessionService(IGenericRepository<SessionEntity> repository, IMapper mapper)
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

        public IEnumerable<Session> Get(Func<Session, bool> predicate, CancellationToken ct)
        {
             return _mapper.Map<IEnumerable<Session>>(_repository.Get(_mapper.Map<Func<SessionEntity, bool>>(predicate), ct));
        }

        public async Task<Session> GetById(int id, CancellationToken ct)
        {
            return _mapper.Map<Session>(await _repository.GetById(id, ct));
        }

        public async Task<Session> Put(Session entity, CancellationToken ct)
        {
            var mappedObject = _mapper.Map<SessionEntity>(entity);
            return _mapper.Map<Session>(await _repository.Update(mappedObject, ct));
        }

        public Task Delete(Session entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, CancellationToken ct)
        {
            return _repository.Delete(id, ct);
        }
    }
}