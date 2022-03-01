using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.DAL.Entities
{
    public class QuestionsQuestionSetsEntity
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public virtual QuestionEntity Question { get; set; }
        public int QuestionSetId { get; set; }
        public virtual QuestionSetEntity QuestionSet { get; set; }
}
}
