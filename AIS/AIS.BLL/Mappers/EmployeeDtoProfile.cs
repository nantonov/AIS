using AIS.BLL.Models;
using AIS.DAL.Entities;
using AutoMapper;

namespace AIS.BLL.Mappers
{
    public class EmployeeDtoProfile : Profile
    {
        public EmployeeDtoProfile()
        {
            CreateMap<EmployeeDto, Employee>().ReverseMap();
        }
    }
}
