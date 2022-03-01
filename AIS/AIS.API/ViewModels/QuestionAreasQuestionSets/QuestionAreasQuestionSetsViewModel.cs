
using AIS.API.ViewModels.QuestionArea;
using AIS.API.ViewModels.QuestionSet;

namespace AIS.API.ViewModels.QuestionAreasQuestionSets
{
    public class QuestionAreasQuestionSetsViewModel
    {
        public int Id { get; set; }
        public int QuestionAreaId { get; set; }
        public ShortQuestionAreaViewModel QuestionArea { get; set; }
        public int QuestionSetId { get; set; }
        public ShortQuestionSetViewModel QuestionSet { get; set; }
    }
}
