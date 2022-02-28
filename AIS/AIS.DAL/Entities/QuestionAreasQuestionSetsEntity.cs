
namespace AIS.DAL.Entities
{
    public class QuestionAreasQuestionSetsEntity
    {
        public int Id { get; set; }
        public int QuestionAreaId { get; set; }
        public virtual QuestionAreaEntity QuestionArea { get; set; }
        public int QuestionSetId { get; set; }
        public virtual QuestionSetEntity QuestionSet { get; set; }
    }
}
