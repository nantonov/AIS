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

        public int MethodForTest1()
        {
            int i = 10;
            int j = 0;
            i++;
            i--;
            i-= 20;
            for (;i<100;i++)
            {
                if (i % 2 > 0) j += i;
            }
            return j;
        }

        public int MethodForTest2()
        {
            int i = 10;
            int j = 0;
            i++;
            i--;
            i -= 20;
            for (; i < 100; i++)
            {
                if (i % 2 == 0) j += i;
            }
            return j;
        }

        public int MethodForTest3()
        {
            int i = 10;
            int j = 0;
            i++;
            i--;
            i -= 100;
            for (; i < 100; i++)
            {
                if (i < 0) j += i;
            }
            return j;
        }
    }
}