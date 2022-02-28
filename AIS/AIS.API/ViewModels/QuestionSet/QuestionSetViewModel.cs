using System.Collections.Generic;
using AIS.API.ViewModels.Question;
using AIS.API.ViewModels.QuestionArea;

namespace AIS.API.ViewModels.QuestionSet
{
    public class QuestionSetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ShortQuestionAreaViewModel> QuestionAreas { get; set; }
        public IEnumerable<ShortQuestionViewModel> Questions { get; set; }
    }
}
