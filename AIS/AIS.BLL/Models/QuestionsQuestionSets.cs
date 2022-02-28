using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.BLL.Models
{
    public class QuestionsQuestionSetsEntity
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public int QuestionSetId { get; set; }
        public virtual QuestionSet QuestionSet { get; set; }
}
}
