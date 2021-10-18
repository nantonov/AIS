using AIS.BLL.Models;
using AIS.DAL.Entities;
using AutoMapper;

namespace AIS.BLL.Mapper
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<SessionEntity, Session>();
        }
    }
}