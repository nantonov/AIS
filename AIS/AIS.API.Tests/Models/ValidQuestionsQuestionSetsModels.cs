using AIS.BLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.API.Tests.Controllers.Models
{
    public static class ValidQuestionsQuestionSetsModels
    {
        public static readonly QuestionsQuestionSets questionsQuestionSetsViewModelAddWithId = new()
        {
            Id = 1,
            QuestionId = 1,
            QuestionSetId = 1
        };

        public static readonly QuestionsQuestionSets questionsQuestionSetsViewModelAdd = new()
        {
            QuestionId = 1,
            QuestionSetId = 1
        };

        public static readonly QuestionsQuestionSets questionsQuestionSetsViewModelUpdateWithId = new()
        {
            Id = 2,
            QuestionId = 1,
            QuestionSetId = 1
        };

        public static readonly QuestionsQuestionSets questionsQuestionSetsViewModelUpdate = new()
        {
            QuestionId = 1,
            QuestionSetId = 1
        };

        public static readonly ImmutableList<QuestionsQuestionSets> questionsQuestionSetsModelsGet = new List<QuestionsQuestionSets>()
            {
                new()
                {
                    Id = 1,
                    QuestionId = 1,
                    QuestionSetId = 1
                },
                new()
                {
                    Id = 2,
                    QuestionId = 1,
                    QuestionSetId = 2
                }
            }.ToImmutableList();

        public static readonly QuestionsQuestionSets questionsQuestionSetsViewModelGetById = new()
        {
            Id = 2,
            QuestionId = 1,
            QuestionSetId = 1
        };
    }
}
