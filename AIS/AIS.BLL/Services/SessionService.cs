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

        public int MethodToTest()
        {
            int i = 20;
            i = 22;
            if (i == 22)
            {
                i = 23;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
            }
            return i;
        }

        public int MethodToTest2()
        {
            int i;
            for (i = 2; i < 20; i += i / 2) { };
            return 0;
        }

        public int MethodToTestCopy()
        {
            int i = 20;
            i = 22;
            if (i == 22) {
                i = 23;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
                i++;
            }
            return i;
        }
    }
}