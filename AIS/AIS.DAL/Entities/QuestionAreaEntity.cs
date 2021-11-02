using System.Collections.Generic;

namespace AIS.DAL.Entities
{
    public class QuestionAreaEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<QuestionSetEntity> QuestionSets { get; set; }
    }
}
