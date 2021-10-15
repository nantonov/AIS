﻿using AIS.BLL.Models;
using AIS.DAL.Entities;
using AutoMapper;

namespace AIS.BLL.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeEntity>().ReverseMap();
        }
    }
}
