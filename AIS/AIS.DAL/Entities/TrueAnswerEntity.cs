namespace AIS.DAL.Entities
{
    public class TrueAnswerEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionEntity Question { get; set; }
        public int QuestionId { get; set; }
    }
}
