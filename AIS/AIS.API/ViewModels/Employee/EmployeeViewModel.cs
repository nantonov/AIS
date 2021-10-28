using AIS.API.ViewModels.Company;

namespace AIS.API.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public ShortEmployeeViewModel Company { get; set; }
    }
}
