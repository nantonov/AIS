using AIS.BLL.Models;

namespace AIS.BLL.Interfaces.Services
{
    public interface ISessionService : IGenericService<Session>
    {
        int MethodToTest();
        int MethodToTestCopy();
        int MethodToTest2();
    }
}