using AIS.API.ViewModels.QuestionSet;
using AIS.API.ViewModels.TrueAnswer;
using System.Collections.Generic;

namespace AIS.API.ViewModels.Question
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual IEnumerable<ShortQuestionSetViewModel> QuestionSets { get; set; }
        public int TrueAnswerId { get; set; }
        public ShortTrueAnswerViewModel TrueAnswer { get; set; }
    }
}
