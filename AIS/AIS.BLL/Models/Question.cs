namespace AIS.BLL.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionSetId { get; set; }
        public QuestionSet QuestionSet { get; set; }
        public int TrueAnswerId { get; set; }
        public TrueAnswer TrueAnswer { get; set; }
    }
}
