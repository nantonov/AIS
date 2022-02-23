using AIS.BLL.Constants;
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
    public class NextQuestionService: INextQuestionService
    {
        private readonly IGenericRepository<QuestionEntity> _questions;
        private readonly IGenericRepository<QuestionIntervieweeAnswerEntity> _answers;
        private readonly IMapper _mapper;

        public NextQuestionService (IGenericRepository<QuestionEntity> questions,
            IGenericRepository<QuestionIntervieweeAnswerEntity> answers,
            IMapper mapper)
        {
            _questions = questions;
            _answers = answers;
            _mapper = mapper;
        }

        public async Task<Question> next(int sessionId, int setId, CancellationToken ct)
        {
            List<QuestionEntity> questions = (await _questions.Get(ct)).Where(item=> item.QuestionSetId == setId).ToList();
            var answers = (await _answers.Get(ct)).Where(item=>item.SessionId==sessionId);

            questions = questions.Where(question=> !answers.Any(answer=>answer.QuestionId==question.Id)).ToList();
            if (questions.Count > 0)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, questions.Count);
                return _mapper.Map<Question>(questions[index]);
            }
            return EmptyQuestion.Empty;
        }
    }
}
