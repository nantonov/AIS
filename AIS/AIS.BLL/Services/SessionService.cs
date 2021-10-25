using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;

namespace AIS.BLL.Services
{
    public class SessionService : GenericService<Session,SessionEntity>, ISessionService
    {
        public SessionService(ISessionRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}