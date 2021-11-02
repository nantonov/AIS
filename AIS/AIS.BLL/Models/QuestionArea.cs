using System.Collections.Generic;

namespace AIS.BLL.Models
{
    public class QuestionArea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<QuestionSet> QuestionSets { get; set; }
    }
}
