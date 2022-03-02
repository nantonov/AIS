using AIS.BLL.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AIS.BLL.Tests.Models
{
    public static class ValidQuestionsQuestionSetsModels
    {
        public static readonly ImmutableList<QuestionsQuestionSets> questionsQuestionSetsModelsGet = new List<QuestionsQuestionSets>()
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

        public static readonly QuestionsQuestionSets questionsQuestionSetsModelGetById = new()
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

        public static readonly QuestionsQuestionSets questionsQuestionSetsModelDelete = new()
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

        public static readonly QuestionsQuestionSets questionsQuestionSetsModelPut = new()
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

        public static readonly QuestionsQuestionSets questionsQuestionSetsModelWithIdAdd = new()
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

        public static readonly QuestionsQuestionSets questionsQuestionSetsModelAdd = new()
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

        public static readonly ImmutableList<QuestionsQuestionSets> questionsQuestionSetsModelsGetByPredicate = new List<QuestionsQuestionSets>()
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
