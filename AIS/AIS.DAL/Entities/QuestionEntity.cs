namespace AIS.DAL.Entities
{
    public class QuestionEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionSetEntity QuestionSet { get; set; }
        public int QuestionSetId { get; set; }
        public TrueAnswerEntity TrueAnswer { get; set; }
    }
}
