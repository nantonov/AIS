using AIS.API.ViewModels.Employee;
using AIS.BLL.Models;
using AutoMapper;

namespace AIS.API.Mappers
{
    public class EmployeeViewModelProfile : Profile
    {
        public EmployeeViewModelProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<ChangeEmployeeViewModel, Employee>();
        }
    }
}
