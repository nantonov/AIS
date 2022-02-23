using AIS.API.ViewModels.Question;
using AIS.API.ViewModels.TrueAnswer;
using AIS.API.ViewModels.Session;

namespace AIS.API.ViewModels.QuestionIntervieweeAnswer
{
    public class QuestionIntervieweeAnswerViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }
        public int TrueAnswerId { get; set; }
        public ShortTrueAnswerViewModel TrueAnswer { get; set; }
        public int QuestionId { get; set; }
        public ShortQuestionViewModel Question { get; set; }
        public int? SessionId { get; set; }
        public ShortSessionViewModel Session { get; set; }
    }
}
