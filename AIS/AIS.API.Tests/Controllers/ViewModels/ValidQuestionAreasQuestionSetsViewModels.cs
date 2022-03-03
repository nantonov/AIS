using AIS.API.ViewModels.QuestionAreasQuestionSets;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AIS.API.Tests.Controllers.ViewModels
{
    public static class ValidQuestionAreasQuestionSetsViewModels
    {
        public static readonly QuestionAreasQuestionSetsViewModel questionAreasQuestionSetsViewModelAddWithId = new()
        {
            Id = 1,
            QuestionAreaId = 1,
            QuestionSetId = 1
        };
        public static readonly ChangeQuestionAreasQuestionSetsViewModel questionAreasQuestionSetsViewModelAdd = new()
        {
            QuestionAreaId = 1,
            QuestionSetId = 1
        };

        public static readonly QuestionAreasQuestionSetsViewModel questionAreasQuestionSetsViewModelUpdateWithId = new()
        {
            Id = 2,
            QuestionAreaId = 1,
            QuestionSetId = 1
        };
        public static readonly ChangeQuestionAreasQuestionSetsViewModel questionAreasQuestionSetsViewModelUpdate = new()
        {
            QuestionAreaId = 1,
            QuestionSetId = 1
        };

        public static readonly ImmutableList<ShortQuestionAreasQuestionSetsViewModel> questionAreasQuestionSetsViewModelsGet = new List<ShortQuestionAreasQuestionSetsViewModel>()
            {
                new()
                {
                    Id = 1,
                    QuestionAreaId = 1,
                    QuestionSetId = 1
                },
                new()
                {
                    Id = 2,
                    QuestionAreaId = 1,
                    QuestionSetId = 2
                }
            }.ToImmutableList();

        public static readonly QuestionAreasQuestionSetsViewModel questionAreasQuestionSetsViewModelGetById = new()
        {
            Id = 2,
            QuestionAreaId = 1,
            QuestionSetId = 1
        };
    }
}
