using System.Collections.Generic;
using AIS.API.ViewModels.Question;
using AIS.API.ViewModels.QuestionArea;

namespace AIS.API.ViewModels.QuestionSet
{
    public class QuestionSetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuestionAreaId { get; set; }
        public ShortQuestionAreaViewModel QuestionArea { get; set; }
        public IEnumerable<ShortQuestionViewModel> Questions { get; set; }
    }
}
