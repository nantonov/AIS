using System.Collections.Generic;

namespace AIS.API.ViewModels.QuestionSet
{
    public class QuestionSetAddViewModel
    {
#nullable disable
        public string Name { get; set; }
#nullable enable
        public IEnumerable<int>? QuestionAreaIds { get; set; }
        public IEnumerable<int>? QuestionIds { get; set; }
    }
}
