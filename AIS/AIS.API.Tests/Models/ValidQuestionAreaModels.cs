using AIS.BLL.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AIS.API.Tests.Models
{
    public static class ValidQuestionAreaModels
    {
        public static readonly QuestionArea questionAreaModel = new()
        {
            Id = 1,
            Name = "Junior .NET",
            QuestionSetsIds = new List<int> { 1, 2, 3, 4, 5 }
        };

        public static readonly QuestionArea deleteQuestionAreaModel = new()
        {
            Id = 3,
            Name = "Junior .NET"
        };

        public static readonly ImmutableList<QuestionArea> questionAreasList =
            new List<QuestionArea>()
            {
                new()
                {
                    Name = "Junior .NET"
                },
                new()
                {
                    Name = "Junior React"
                }
            }.ToImmutableList();
    }
}
