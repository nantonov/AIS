using System.Collections.Generic;

namespace AIS.BLL.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Interviewee> Interviewees { get; set; }
    }
}
