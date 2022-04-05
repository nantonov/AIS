using AIS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.BLL.Tests.Entities
{
    public static class ValidQuestionAreaEntities
    {
        public static readonly QuestionAreaEntity questionAreaEntity = new()
        {
            Id = 1,
            Name = "Middle .Net",
            QuestionSets = new List<QuestionSetEntity>
            {
                new()
                {
                    Id =1,
                    Name = "OOP",
                }
            }
        };
        public static readonly QuestionAreaEntity questionAreaAddEntity = new()
        {
            Name = "Middle .Net"
        };
        public static readonly IEnumerable<QuestionAreaEntity> questionAreaModelList = new List<QuestionAreaEntity>
        {
            new()
            {
                Id = 1,
                Name = "Middle .Net"
            },
            new()
            {
                Id = 2,
                Name = "Middle Front"
            }
        };
    }
}
