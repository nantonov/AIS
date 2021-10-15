using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;

namespace AIS.BLL.Services
{
    public class IntervieweeService : IGenericService<Interviewee>
    {
        private readonly IGenericRepository<IntervieweeEntity> _repo;
        private readonly IMapper _mapper;

        public IntervieweeService(IGenericRepository<IntervieweeEntity> repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        public async Task<Interviewee> Add(Interviewee entity, CancellationToken ct)
        {
            return _mapper.Map<Interviewee>(
                await _repo.Add(_mapper.Map<IntervieweeEntity>(entity), ct)
            );
        }

        public async Task<IEnumerable<Interviewee>> Get(CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<Interviewee>>(
                await _repo.Get(ct)
            );
        }

        public IEnumerable<Interviewee> Get(Func<Interviewee, bool> predicate, CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<Interviewee>>(
                _repo.Get(_mapper.Map<Func<IntervieweeEntity, bool>>(predicate), ct)
            );
        }

        public async Task<Interviewee> GetById(int id, CancellationToken ct)
        {
            return _mapper.Map<Interviewee>(
                await _repo.GetById(id, ct)
            );
        }

        public async Task<Interviewee> Put(Interviewee entity, CancellationToken ct)
        {
            return _mapper.Map<Interviewee>(
                await _repo.Update(_mapper.Map<IntervieweeEntity>(entity), ct)
            );
        }

        public Task Delete(Interviewee entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, CancellationToken ct)
        {
            return _repo.Delete(id, ct);
        }
    }
}
