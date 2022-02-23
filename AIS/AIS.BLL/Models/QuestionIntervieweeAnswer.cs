namespace AIS.BLL.Models
{
    public class QuestionIntervieweeAnswer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int TrueAnswerId { get; set; }
        public TrueAnswer TrueAnswer { get; set; }
        public int? SessionId { get; set; }
        public Session Session { get; set; }
    }
}
