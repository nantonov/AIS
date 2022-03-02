using AIS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.BLL.Tests.Entities
{
    public static class ValidQuestionAreasQuestionSetsEntities
    {
        public static List<QuestionAreasQuestionSetsEntity> questionAreasQuestionSetsEntitiesGet = new()
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
        };
        public static QuestionAreasQuestionSetsEntity questionAreasQuestionSetsEntityGetById = new()
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

        public static QuestionAreasQuestionSetsEntity questionAreasQuestionSetsEntityDelete = new()
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

        public static QuestionAreasQuestionSetsEntity questionAreasQuestionSetsEntityPut = new()
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

        public static QuestionAreasQuestionSetsEntity questionAreasQuestionSetsEntityAdd = new()
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

        public static QuestionAreasQuestionSetsEntity questionAreasQuestionSetsEntityAddWithId = new()
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

        public static List<QuestionAreasQuestionSetsEntity> questionAreasQuestionSetsEntitiesGetByPredicate = new()
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
        };
    }
}
