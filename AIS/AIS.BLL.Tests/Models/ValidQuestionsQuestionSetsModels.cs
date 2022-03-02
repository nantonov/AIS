using AIS.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.BLL.Tests.Models
{
    public static class ValidQuestionsQuestionSetsModels
    {
        public static List<QuestionsQuestionSets> questionsQuestionSetsModelsGet = new()
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
        public static QuestionsQuestionSets questionsQuestionSetsModelGetById = new()
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
        public static QuestionsQuestionSets questionsQuestionSetsModelDelete = new()
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

        public static QuestionsQuestionSets questionsQuestionSetsModelPut = new()
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
        public static QuestionsQuestionSets questionsQuestionSetsModelWithIdAdd = new()
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
        public static QuestionsQuestionSets questionsQuestionSetsModelAdd = new()
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

        public static List<QuestionsQuestionSets> questionsQuestionSetsModelsGetByPredicate = new()
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
