namespace AIS.DAL.Entities
{
    public class QuestionEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual QuestionSetEntity QuestionSet { get; set; }
        public int QuestionSetId { get; set; }
        public virtual TrueAnswerEntity TrueAnswer { get; set; }
    }
}
