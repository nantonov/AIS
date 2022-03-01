using System.Collections.Generic;

namespace AIS.DAL.Entities
{
    public class QuestionEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<QuestionSetEntity> QuestionSets { get; set; }
        public virtual ICollection<QuestionsQuestionSetsEntity> QuestionsQuestionSets { get; set; }
        public virtual TrueAnswerEntity TrueAnswer { get; set; }
    }
}
