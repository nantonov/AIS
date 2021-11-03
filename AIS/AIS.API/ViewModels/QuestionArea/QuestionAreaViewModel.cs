using System.Collections.Generic;
using AIS.API.ViewModels.QuestionSet;

namespace AIS.API.ViewModels.QuestionArea
{
    public class QuestionAreaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ShortQuestionSetViewModel> QuestionSets { get; set; }
    }
}
