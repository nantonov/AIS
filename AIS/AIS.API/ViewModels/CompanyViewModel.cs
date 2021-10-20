using AIS.API.ViewModels.Employee;
using System.Collections.Generic;

namespace AIS.API.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
        public IEnumerable<IntervieweeViewModel> Interviewees { get; set; }
    }
}
