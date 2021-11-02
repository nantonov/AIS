using AIS.API.ViewModels.Question;

namespace AIS.API.ViewModels.TrueAnswer
{
    public class TrueAnswerViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public QuestionViewModel Question { get; set; }
    }
}
