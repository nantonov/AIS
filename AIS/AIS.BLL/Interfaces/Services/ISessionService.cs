using AIS.BLL.Models;

namespace AIS.BLL.Interfaces.Services
{
    public interface ISessionService : IGenericService<Session>
    {
        int MethodForTest1();
        int MethodForTest2();
        int MethodForTest3();
    }
}