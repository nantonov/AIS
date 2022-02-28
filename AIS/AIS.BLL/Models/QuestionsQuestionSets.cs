using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.BLL.Models
{
    public class QuestionsQuestionSets
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int QuestionSetId { get; set; }
        public QuestionSet QuestionSet { get; set; }
    }
}
