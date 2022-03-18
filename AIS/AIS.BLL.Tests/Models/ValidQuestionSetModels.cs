using System.Collections.Generic;
using AIS.BLL.Models;

namespace AIS.BLL.Tests.Models
{
    public static class ValidQuestionSetModels
    {
        public static readonly QuestionSet questionSetModel = new()
        {
            Id=1,
            Name = "OOP",
            QuestionAreas = new List<QuestionArea>()
            {
                new()
                {
                    Id =1,
                    Name = "C#",
                }
            }
        };

        public static readonly QuestionSet questionSetAddModel = new()
        {
            Name = "OOP",
            QuestionIds = new List<int> {1, 5, 3},
            QuestionAreaIds = new List<int> {2, 5, 1}
        };

        public static readonly IEnumerable<QuestionSet> questionSetModelList = new List<QuestionSet>()
        {
            new()
            {
                Id = 1,
                Name = "OOP"
            },
            new()
            {
                Id = 2,
                Name = "GC"
            }
        };
    }
}
