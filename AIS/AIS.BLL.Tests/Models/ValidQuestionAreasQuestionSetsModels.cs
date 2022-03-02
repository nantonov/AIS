using AIS.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.BLL.Tests.Models
{
    public static class ValidQuestionAreasQuestionSetsModels
    {
        public static List<QuestionAreasQuestionSets> questionAreasQuestionSetsModelsGet = new()
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
        public static QuestionAreasQuestionSets questionAreasQuestionSetsModelGetById = new()
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

        public static QuestionAreasQuestionSets questionAreasQuestionSetsModelDelete = new()
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

        public static QuestionAreasQuestionSets questionAreasQuestionSetsModelPut = new()
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

        public static QuestionAreasQuestionSets questionAreasQuestionSetsModelAdd = new()
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

        public static QuestionAreasQuestionSets questionAreasQuestionSetsModelAddWithId = new()
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

        public static List<QuestionAreasQuestionSets> questionAreasQuestionSetsModelsGetByPredicate = new()
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
        };
    }
}
