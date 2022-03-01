using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.BLL.Models
{
    public class QuestionAreasQuestionSets
    {
        public int Id { get; set; }
        public int QuestionAreaId { get; set; }
        public QuestionArea QuestionArea { get; set; }
        public int QuestionSetId { get; set; }
        public QuestionSet QuestionSet { get; set; }
    }
}
