using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.DAL.Entities;
using AIS.DAL.Interfaces.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace AIS.BLL.Services
{
    public class NextQuestionService: INextQuestionService
    {
        private readonly ISessionRepository _sessions;
        private readonly IMapper _mapper;

        public NextQuestionService (ISessionRepository sessions, IMapper mapper)
        {
            _sessions = sessions;
            _mapper = mapper;
        }

        public async Task<Question> NextQuestion(int sessionId, CancellationToken ct)
        {
            var session = await _sessions.GetById(sessionId, ct);
            var sets = session?.QuestionArea.QuestionSets;
            var answers = session?.QuestionIntervieweeAnswers;
            List<QuestionEntity> questions = null;
            if (sets is null) return null;
            if (answers.Count == 0) questions = sets.First().Questions.ToList();
            else
            {
                foreach(var set in sets)
                {
                    if (answers.Count(answer => answer.Question.QuestionSetId == set.Id) != set.Questions.Count)
                    {
                        questions = set.Questions.ToList();
                        break;
                    }
                }
            }
            questions = questions?.Where(question=>!answers.Any(answer => answer.QuestionId == question.Id)).ToList();

            if (questions is not null)
            {
                int index = RandomNumberGenerator.GetInt32(0, questions.Count);
                return _mapper.Map<Question>(questions[index]);
            }
            return null;
        }
    }
}
