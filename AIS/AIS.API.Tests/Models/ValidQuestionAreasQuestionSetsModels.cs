using AIS.BLL.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AIS.API.Tests.Controllers.Models
{
    public static class ValidQuestionAreasQuestionSetsModels
    {
        public static readonly QuestionAreasQuestionSets questionAreasQuestionSetsModelAddWithId = new()
        {
            Id = 1,
            QuestionAreaId = 1,
            QuestionSetId = 1
        };
        public static readonly QuestionAreasQuestionSets questionAreasQuestionSetsModelAdd = new()
        {
            QuestionAreaId = 1,
            QuestionSetId = 1
        };

        public static readonly QuestionAreasQuestionSets questionAreasQuestionSetsModelUpdateWithId = new()
        {
            Id = 2,
            QuestionAreaId = 1,
            QuestionSetId = 1
        };
        public static readonly QuestionAreasQuestionSets questionAreasQuestionSetsModelUpdate = new()
        {
            QuestionAreaId = 1,
            QuestionSetId = 1
        };

        public static readonly ImmutableList<QuestionAreasQuestionSets> questionAreasQuestionSetsModelsGet = new List<QuestionAreasQuestionSets>()
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

        public static readonly QuestionAreasQuestionSets questionAreasQuestionSetsModelGetById = new()
        {
            Id = 2,
            QuestionAreaId = 1,
            QuestionSetId = 1
        };
    }
}
