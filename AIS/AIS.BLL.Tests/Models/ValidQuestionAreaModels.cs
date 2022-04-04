using AIS.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.BLL.Tests.Models
{
    public static class ValidQuestionAreaModels
    {
        public static readonly QuestionArea questionAreaModel = new()
        {
            Id = 1,
            Name = "Juniour .NET",
            QuestionSets = new List<QuestionSet>()
            {
                new()
                {
                    Id =1,
                    Name = "OOP",
                }
            }
        };

        public static readonly QuestionArea questionAreaAddModel = new()
        {
            Name = "Juniour .NET",
            QuestionSetsIds = new List<int> { 1, 5, 3 }
        };

        public static readonly IEnumerable<QuestionArea> questionAreaModelList = new List<QuestionArea>()
        {
            new()
            {
                Id = 1,
                Name = "Juniour .NET"
            },
            new()
            {
                Id = 2,
                Name = "Juniour+ .NET"
            }
        };
    }
}
