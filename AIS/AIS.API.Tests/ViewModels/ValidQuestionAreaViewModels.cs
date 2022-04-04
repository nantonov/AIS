using AIS.API.ViewModels.QuestionArea;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AIS.API.Tests.ViewModels
{
    public static class ValidQuestionAreaViewModels
    {
        public static readonly QuestionAreaAddViewModel questionAreaAddViewModel = new()
        {
            Name = "Junior .NET",
            QuestionSetsIds = new List<int> { 1, 2, 3, 4, 5 }
        };

        public static readonly QuestionAreaViewModel questionAreaViewModel = new()
        {
            Id = 1,
            Name = "Junior .NET"
        };

        public static readonly QuestionAreaViewModel deleteQuestionAreaViewModel = new()
        {
            Id = 3,
            Name = "Junior .NET"
        };

        public static readonly QuestionAreaUpdateViewModel questionAreaUpdateViewModel = new()
        {
            Name = "Junior .NET"
        };

        public static readonly ImmutableList<ShortQuestionAreaViewModel> questionAreasList =
           new List<ShortQuestionAreaViewModel>()
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

        public static readonly IEnumerable<ShortQuestionAreaViewModel> questionAreasEmptyShortList =
            new List<ShortQuestionAreaViewModel>();
    }
}
