using System;
using System.Collections.Generic;
using AIS.API.ViewModels.Company;
using AIS.API.ViewModels.Employee;
using AIS.API.ViewModels.Interviewee;
using AIS.API.ViewModels.QuestionArea;
using AIS.API.ViewModels.QuestionIntervieweeAnswer;

namespace AIS.API.ViewModels.Session
{
    public class SessionViewModel
    {
        public int Id { get; set; }
        public DateTime StartedAt { get; set; }
        public int CompanyId { get; set; }
        public ShortCompanyViewModel Company { get; set; }
        public int EmployeeId { get; set; }
        public ShortEmployeeViewModel Employee { get; set; }
        public int IntervieweeId { get; set; }
        public ShortIntervieweeViewModel Interviewee { get; set; }
        public DateTime FinishedAt { get; set; }
        public int QuestionAreaId { get; set; }
        public ShortQuestionAreaViewModel QuestionArea { get; set; }
        public IEnumerable<ShortQuestionIntervieweeAnswerViewModel> QuestionIntervieweeAnswers { get; set; }
    }
}