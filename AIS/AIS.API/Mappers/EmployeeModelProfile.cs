using AIS.API.ViewModels;
using AIS.BLL.Models;
using AutoMapper;

namespace AIS.API.Mappers
{
    public class EmployeeModelProfile : Profile
    {
        public EmployeeModelProfile()
        {
            CreateMap<EmployeeModel, EmployeeDto>().ReverseMap();
        }
    }
}
