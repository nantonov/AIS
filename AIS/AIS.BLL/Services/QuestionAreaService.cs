using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.BLL.Services
{
    public class QuestionAreaService : GenericService<QuestionArea, QuestionAreaEntity>, IQuestionAreaService
    {
        private readonly IQuestionAreaRepository _questionAreaRepository;
        private readonly IQuestionAreasQuestionSetsRepository _questionAreasQuestionSetsRepository;
        private readonly IMapper _mapper;
        public QuestionAreaService(IQuestionAreaRepository repository, IQuestionAreasQuestionSetsRepository questionAreasQuestionSetsRepository,
            IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
            _questionAreaRepository = repository;
            _questionAreasQuestionSetsRepository = questionAreasQuestionSetsRepository;
        }

        public override async Task<QuestionArea> Add(QuestionArea entity, CancellationToken ct)
        {
            var questionSetsIds = entity.QuestionSetsIds?.ToList();
            var res = await _questionAreaRepository.Add(_mapper.Map<QuestionAreaEntity>(entity), ct);

            if (questionSetsIds is not null)
            {
                var areasList = questionSetsIds.Select(id => new QuestionAreasQuestionSetsEntity { QuestionAreaId = res.Id, QuestionSetId = id }).ToList();
                await _questionAreasQuestionSetsRepository.AddRange(areasList, ct);
            }

            return _mapper.Map<QuestionArea>(res);
        }
    }
}
