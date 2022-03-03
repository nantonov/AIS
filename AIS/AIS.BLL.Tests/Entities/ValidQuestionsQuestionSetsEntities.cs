using AIS.DAL.Entities;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AIS.BLL.Tests.Entities
{
    public static class ValidQuestionsQuestionSetsEntities
    {
        public static readonly ImmutableList<QuestionsQuestionSetsEntity> questionsQuestionSetsEntitiesGet = new List<QuestionsQuestionSetsEntity>()
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
        }.ToImmutableList();

        public static readonly QuestionsQuestionSetsEntity questionsQuestionSetsEntityGetById = new()
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

        public static readonly QuestionsQuestionSetsEntity questionsQuestionSetsEntityDelete = new()
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

        public static readonly QuestionsQuestionSetsEntity questionsQuestionSetsEntityPut = new()
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

        public static readonly QuestionsQuestionSetsEntity questionsQuestionSetsEntityWithIdAdd = new()
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

        public static readonly QuestionsQuestionSetsEntity questionsQuestionSetsEntityAdd = new()
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

        public static readonly ImmutableList<QuestionsQuestionSetsEntity> questionsQuestionSetsEntitiesGetByPredicate = new List<QuestionsQuestionSetsEntity>()
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
        }.ToImmutableList();
    }
}
