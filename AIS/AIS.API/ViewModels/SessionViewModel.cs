using System;
using AIS.API.ViewModels.Company;
using AIS.API.ViewModels.Interviewee;

namespace AIS.API.ViewModels
{
    public class SessionViewModel
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int CompanyId { get; set; }
        public CompanyViewModel Company { get; set; }
        public int EmployeeId { get; set; }
        public int IntervieweeId { get; set; }
        public IntervieweeViewModel Interviewee { get; set; }
        public int QuestionAreaId { get; set; }
    }
}