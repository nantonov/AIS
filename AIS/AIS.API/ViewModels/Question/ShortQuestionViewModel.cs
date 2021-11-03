namespace AIS.API.ViewModels.Question
{
    public class ShortQuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionSetId { get; set; }
        public int TrueAnswerId { get; set; }
    }
}
