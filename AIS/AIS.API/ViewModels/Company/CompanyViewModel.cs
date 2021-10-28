using System.Collections.Generic;
using AIS.API.ViewModels.Employee;
using AIS.API.ViewModels.Interviewee;

namespace AIS.API.ViewModels.Company
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ShortEmployeeViewModel> Employees { get; set; }
        public IEnumerable<ShortIntervieweeViewModel> Interviewees { get; set; }
    }
}
