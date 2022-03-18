using System.Collections.Generic;

namespace AIS.BLL.Models
{
    public class QuestionSet
    {
#nullable disable
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<QuestionArea> QuestionAreas { get; set; }
        public IEnumerable<Question> Questions { get; set; }
#nullable enable
        public IEnumerable<int>? QuestionAreaIds { get; set; }
        public IEnumerable<int>? QuestionIds { get; set; }
    }
}
