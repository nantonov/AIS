namespace AIS.DAL.Entities
{
    public class QuestionIntervieweeAnswerEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }
        public int QuestionId { get; set; }
        public virtual QuestionEntity Question { get; set; }
        public int? SessionId { get; set; }
        public virtual SessionEntity Session { get; set; }
    }
}
