using System.Collections.Generic;

namespace AIS.API.ViewModels.QuestionArea
{
    public class QuestionAreaAddViewModel
    {
        public string Name { get; set; }
#nullable enable
        public IEnumerable<int>? QuestionSetsIds { get; set; }
    }
}
