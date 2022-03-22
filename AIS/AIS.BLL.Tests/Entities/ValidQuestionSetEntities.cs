using System.Collections.Generic;
using AIS.BLL.Models;
using AIS.DAL.Entities;

namespace AIS.BLL.Tests.Entities
{
    public static class ValidQuestionSetEntities
    {
        public static readonly QuestionSetEntity questionSetModel = new()
        {
            Id = 1,
            Name = "OOP",
            QuestionAreas = new List<QuestionAreaEntity>
            {
                new()
                {
                    Id =1,
                    Name = "C#",
                }
            }
        };
        public static readonly QuestionSetEntity questionSetAddEntity = new()
        {
            Name = "OOP"
        };
        public static readonly IEnumerable<QuestionSetEntity> questionSetModelList = new List<QuestionSetEntity>
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
