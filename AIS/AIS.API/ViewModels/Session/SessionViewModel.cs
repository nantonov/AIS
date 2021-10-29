using System;
using AIS.API.ViewModels.Company;
using AIS.API.ViewModels.Employee;
using AIS.API.ViewModels.Interviewee;

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
    }
}