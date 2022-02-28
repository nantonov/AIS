using System.Collections.Generic;

namespace AIS.BLL.Models
{
    public class QuestionSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<QuestionArea> QuestionAreas { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}
