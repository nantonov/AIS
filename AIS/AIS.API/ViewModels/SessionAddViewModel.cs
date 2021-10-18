using AIS.BLL.Models;
using System;

namespace AIS.API.ViewModels
{
    public class SessionAddViewModel
    {
        public DateTime StartTime { get; set; }
        public int CompanyId { get; set; }
        public Company _Company { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int IntervieweeId { get; set; }
        public Interviewee interviewee { get; set; }
        public int QuestionAreaId { get; set; }
        // public QuestionArea QuestionArea { get; set; }
    }
}