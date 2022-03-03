using AIS.DAL.Entities;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AIS.BLL.Tests.Entities
{
    public static class ValidQuestionAreasQuestionSetsEntities
    {
        public static readonly ImmutableList<QuestionAreasQuestionSetsEntity> questionAreasQuestionSetsEntitiesGet = new List<QuestionAreasQuestionSetsEntity>()
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

        public static readonly QuestionAreasQuestionSetsEntity questionAreasQuestionSetsEntityGetById = new()
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

        public static readonly QuestionAreasQuestionSetsEntity questionAreasQuestionSetsEntityDelete = new()
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

        public static readonly QuestionAreasQuestionSetsEntity questionAreasQuestionSetsEntityPut = new()
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

        public static readonly QuestionAreasQuestionSetsEntity questionAreasQuestionSetsEntityAdd = new()
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

        public static readonly QuestionAreasQuestionSetsEntity questionAreasQuestionSetsEntityAddWithId = new()
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

        public static readonly ImmutableList<QuestionAreasQuestionSetsEntity> questionAreasQuestionSetsEntitiesGetByPredicate = new List<QuestionAreasQuestionSetsEntity>()
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
                    Id = 2,
                    Name = ".Net middle"
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
