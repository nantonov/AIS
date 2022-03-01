using AIS.API.ViewModels.Question;
using AIS.API.ViewModels.QuestionSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.API.ViewModels.QuestionsQuestionSets
{
    public class QuestionsQuestionSetsViewModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public ShortQuestionViewModel Question { get; set; }
        public int QuestionSetId { get; set; }
        public ShortQuestionSetViewModel QuestionSet { get; set; }
    }
}
