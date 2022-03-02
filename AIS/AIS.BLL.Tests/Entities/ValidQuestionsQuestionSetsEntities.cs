using AIS.DAL.Entities;
using System.Collections.Generic;

namespace AIS.BLL.Tests.Entities
{
    public static class ValidQuestionsQuestionSetsEntities
    {
        public static List<QuestionsQuestionSetsEntity> questionsQuestionSetsEntitiesGet = new()
        {
            new()
            {
                Id = 1,
                QuestionSetId = 1,
                QuestionId = 1,
                Question = new()
                {
                    Id = 1,
                    Text = "What is class ?"
                },
                QuestionSet = new()
                {
                    Id = 1,
                    Name = "c#"
                }
            }
        };
        public static QuestionsQuestionSetsEntity questionsQuestionSetsEntityGetById = new()
        {
            Id = 6,
            QuestionSetId = 1,
            QuestionId = 1,
            Question = new()
            {
                Id = 1,
                Text = "What is class ?"
            },
            QuestionSet = new()
            {
                Id = 1,
                Name = "c#"
            }
        };
        public static QuestionsQuestionSetsEntity questionsQuestionSetsEntityDelete = new()
        {
            Id = 6,
            QuestionSetId = 1,
            QuestionId = 1,
            Question = new()
            {
                Id = 1,
                Text = "What is class ?"
            },
            QuestionSet = new()
            {
                Id = 1,
                Name = "c#"
            }
        };

        public static QuestionsQuestionSetsEntity questionsQuestionSetsEntityPut = new()
        {
            Id = 6,
            QuestionSetId = 1,
            QuestionId = 1,
            Question = new()
            {
                Id = 1,
                Text = "What is class ?"
            },
            QuestionSet = new()
            {
                Id = 1,
                Name = "c#"
            }
        };
        public static QuestionsQuestionSetsEntity questionsQuestionSetsEntityWithIdAdd = new()
        {
            Id = 6,
            QuestionSetId = 1,
            QuestionId = 1,
            Question = new()
            {
                Id = 1,
                Text = "What is class ?"
            },
            QuestionSet = new()
            {
                Id = 1,
                Name = "c#"
            }
        };
        public static QuestionsQuestionSetsEntity questionsQuestionSetsEntityAdd = new()
        {
            QuestionSetId = 1,
            QuestionId = 1,
            Question = new()
            {
                Id = 1,
                Text = "What is class ?"
            },
            QuestionSet = new()
            {
                Id = 1,
                Name = "c#"
            }
        };

        public static List<QuestionsQuestionSetsEntity> questionsQuestionSetsEntitiesGetByPredicate = new()
        {
            new()
            {
                Id = 1,
                QuestionSetId = 1,
                QuestionId = 1,
                Question = new()
                {
                    Id = 1,
                    Text = "What is async/await ?"
                },
                QuestionSet = new()
                {
                    Id = 1,
                    Name = "c#"
                }
            },
            new()
            {
                Id = 2,
                QuestionSetId = 1,
                QuestionId = 2,
                Question = new()
                {
                    Id = 2,
                    Text = "What is class ?"
                },
                QuestionSet = new()
                {
                    Id = 1,
                    Name = "c#"
                }
            }
        };
    }
}
