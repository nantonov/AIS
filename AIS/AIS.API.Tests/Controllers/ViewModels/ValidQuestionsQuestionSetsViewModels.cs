using AIS.API.ViewModels.QuestionsQuestionSets;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AIS.API.Tests.Controllers.ViewModels
{
    public static class ValidQuestionsQuestionSetsViewModels
    {
        public static readonly QuestionsQuestionSetsViewModel questionsQuestionSetsViewModelAddWithId = new()
        {
            Id = 1,
            QuestionId = 1,
            QuestionSetId = 1
        };

        public static readonly ChangeQuestionsQuestionSetsViewModel questionsQuestionSetsViewModelAdd = new()
        {
            QuestionId = 1,
            QuestionSetId = 1
        };

        public static readonly QuestionsQuestionSetsViewModel questionsQuestionSetsViewModelUpdateWithId = new()
        {
            Id = 2,
            QuestionId = 1,
            QuestionSetId = 1
        };

        public static readonly ChangeQuestionsQuestionSetsViewModel questionsQuestionSetsViewModelUpdate = new()
        {
            QuestionId = 1,
            QuestionSetId = 1
        };

        public static readonly ImmutableList<ShortQuestionsQuestionSetsViewModel> questionsQuestionSetsViewModelsGet = new List<ShortQuestionsQuestionSetsViewModel>()
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

        public static readonly QuestionsQuestionSetsViewModel questionsQuestionSetsViewModelGetById = new()
        {
            Id = 2,
            QuestionId = 1,
            QuestionSetId = 1
        };
    }
}
