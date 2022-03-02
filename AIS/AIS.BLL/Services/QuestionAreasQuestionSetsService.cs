using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;

namespace AIS.BLL.Services
{
    public class QuestionAreasQuestionSetsService : GenericService<QuestionAreasQuestionSets, QuestionAreasQuestionSetsEntity>, IQuestionAreasQuestionSetsService
    {
        public QuestionAreasQuestionSetsService(IGenericRepository<QuestionAreasQuestionSetsEntity> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
