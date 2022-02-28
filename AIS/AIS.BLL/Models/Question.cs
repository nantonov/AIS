using System.Collections.Generic;

namespace AIS.BLL.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IEnumerable<QuestionSet> QuestionSets { get; set; }
        public int TrueAnswerId { get; set; }
        public TrueAnswer TrueAnswer { get; set; }
    }
}
