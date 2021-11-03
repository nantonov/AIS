using AIS.API.ViewModels.QuestionSet;
using AIS.API.ViewModels.TrueAnswer;

namespace AIS.API.ViewModels.Question
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionSetId { get; set; }
        public ShortQuestionSetViewModel QuestionSet { get; set; }
        public int TrueAnswerId { get; set; }
        public ShortTrueAnswerViewModel TrueAnswer { get; set; }
    }
}
