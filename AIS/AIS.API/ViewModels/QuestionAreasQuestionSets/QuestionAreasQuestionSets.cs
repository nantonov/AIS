﻿
using AIS.API.ViewModels.QuestionArea;
using AIS.API.ViewModels.QuestionSet;

namespace AIS.API.ViewModels.QuestionAreasQuestionSets
{
    public class QuestionAreasQuestionSets
    {
        public int Id { get; set; }
        public int QuestionAreaId { get; set; }
        public ShortQuestionAreaViewModel QuestionArea { get; set; }
        public int QuestionSetId { get; set; }
        public virtual ShortQuestionSetViewModel QuestionSet { get; set; }
    }
}
