using AIS.BLL.Models;
using System.Collections.Generic;
using System.Collections.Immutable;
using AIS.API.ViewModels.QuestionSet;

namespace AIS.API.Tests.Models
{
    public static class ValidQuestionSetModels
    {
        public static readonly QuestionSetAddViewModel questionSetAddViewModel = new()
        {
            Name = "OOP",
            QuestionAreaIds = new List<int> { 1,2,3,4,5},
            QuestionIds = new List<int> { 1,2,3,4,5},
        };

        public static readonly QuestionSetViewModel questionSetViewModel = new()
        {
            Id = 1,
            Name = "OOP"
        };

        public static readonly QuestionSet questionSetModel = new()
        {
            Id=1,
            Name = "OOP",
            QuestionAreaIds = new List<int> { 1, 2, 3, 4, 5 },
            QuestionIds = new List<int> { 1, 2, 3, 4, 5 },
        };

        public static readonly QuestionSetUpdateViewModel questionSetUpdateViewModel = new()
        {
            Name = "OOP"
        };

        public static readonly QuestionSet deleteQuestionSetModel = new()
        {
            Id = 3,
            Name = "Bob"
        };

        public static readonly ImmutableList<QuestionSetViewModel> questionSetList = 
            new List<QuestionSetViewModel>()
        {
            new()
            {
                Name = "QA"
            },
            new()
            {
                Name = "HR"
            }
        }.ToImmutableList();

        public static readonly IEnumerable<ShortQuestionSetViewModel> questionSetEmptyShortList =
            new List<ShortQuestionSetViewModel>();
    }
}