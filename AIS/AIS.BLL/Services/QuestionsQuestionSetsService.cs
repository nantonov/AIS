using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;

namespace AIS.BLL.Services
{
    public class QuestionsQuestionSetsService : GenericService<QuestionsQuestionSets, QuestionsQuestionSetsEntity>, IQuestionsQuestionSetsService
    {
        public QuestionsQuestionSetsService(IGenericRepository<QuestionsQuestionSetsEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
