using AIS.API.ViewModels.Company;
using AIS.API.ViewModels.Employee;
using AIS.API.ViewModels.Interviewee;

namespace AIS.API.ViewModels.Session
{
    public class SessionAddViewModel
    {
        public CompanyViewModel Company { get; set; }
        public int CompanyId { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public int EmployeeId { get; set; }
        public IntervieweeViewModel Interviewee { get; set; }
        public int IntervieweeId { get; set; }
    }
}