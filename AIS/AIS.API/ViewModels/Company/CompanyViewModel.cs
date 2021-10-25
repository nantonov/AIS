using AIS.API.ViewModels.Employee;
using System.Collections.Generic;
using AIS.API.ViewModels.Interviewee;

 namespace AIS.API.ViewModels.Company
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
        public IEnumerable<IntervieweeViewModel> Interviewees { get; set; }
    }
}
