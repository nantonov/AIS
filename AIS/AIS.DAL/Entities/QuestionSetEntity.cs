using System.Collections.Generic;

namespace AIS.DAL.Entities
{
    public class QuestionSetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual QuestionAreaEntity QuestionArea { get; set; }
        public int QuestionAreaId { get; set; }
        public virtual ICollection<QuestionEntity> Questions { get; set; }
    }
}
