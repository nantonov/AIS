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
        public QuestionAreaViewModel QuestionArea { get; set; }
        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}
