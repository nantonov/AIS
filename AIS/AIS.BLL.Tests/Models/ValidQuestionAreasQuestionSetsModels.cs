using AIS.BLL.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AIS.BLL.Tests.Models
{
    public static class ValidQuestionAreasQuestionSetsModels
    {
        public static readonly ImmutableList<QuestionAreasQuestionSets> questionAreasQuestionSetsModelsGet = new List<QuestionAreasQuestionSets>()
        {
            new()
            {
                Id = 1,
                QuestionSetId = 1,
                QuestionAreaId = 1,
                QuestionArea = new()
                {
                    Id = 1,
                    Name = ".Net junior"
                },
                QuestionSet = new()
                {
                    Id = 1,
                    Name = "C# questions set"
                }
            }
        }.ToImmutableList();

        public static readonly QuestionAreasQuestionSets questionAreasQuestionSetsModelGetById = new()
        {
            Id = 6,
            QuestionSetId = 1,
            QuestionAreaId = 1,
            QuestionArea = new()
            {
                Id = 1,
                Name = ".Net junior"
            },
            QuestionSet = new()
            {
                Id = 1,
                Name = "C# questions set"
            }
        };

        public static readonly QuestionAreasQuestionSets questionAreasQuestionSetsModelDelete = new()
        {
            Id = 6,
            QuestionSetId = 1,
            QuestionAreaId = 1,
            QuestionArea = new()
            {
                Id = 1,
                Name = ".Net junior"
            },
            QuestionSet = new()
            {
                Id = 1,
                Name = "C# questions set"
            }
        };

        public static readonly QuestionAreasQuestionSets questionAreasQuestionSetsModelPut = new()
        {
            Id = 6,
            QuestionSetId = 1,
            QuestionAreaId = 1,
            QuestionArea = new()
            {
                Id = 1,
                Name = ".Net junior"
            },
            QuestionSet = new()
            {
                Id = 1,
                Name = "C# questions set"
            }
        };

        public static readonly QuestionAreasQuestionSets questionAreasQuestionSetsModelAdd = new()
        {
            QuestionSetId = 1,
            QuestionAreaId = 1,
            QuestionArea = new()
            {
                Id = 1,
                Name = ".Net junior"
            },
            QuestionSet = new()
            {
                Id = 1,
                Name = "C# questions set"
            }
        };

        public static readonly QuestionAreasQuestionSets questionAreasQuestionSetsModelAddWithId = new()
        {
            Id = 1,
            QuestionSetId = 1,
            QuestionAreaId = 1,
            QuestionArea = new()
            {
                Id = 1,
                Name = ".Net junior"
            },
            QuestionSet = new()
            {
                Id = 1,
                Name = "C# questions set"
            }
        };

        public static readonly ImmutableList<QuestionAreasQuestionSets> questionAreasQuestionSetsModelsGetByPredicate = new List<QuestionAreasQuestionSets>()
        {
            new()
            {
                Id = 1,
                QuestionSetId = 1,
                QuestionAreaId = 1,
                QuestionArea = new()
                {
                    Id = 1,
                    Name = ".Net junior"
                },
                QuestionSet = new()
                {
                    Id = 1,
                    Name = "C# questions set"
                }
            },
            new()
            {
                Id = 2,
                QuestionSetId = 1,
                QuestionAreaId = 2,
                QuestionArea = new()
                {
                    Id = 1,
                    Name = ".Net junior"
                },
                QuestionSet = new()
                {
                    Id = 1,
                    Name = "C# questions set"
                }
            }
        }.ToImmutableList();
    }
}
