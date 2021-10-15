using System.Collections.Generic;

namespace AIS.DAL.Entities
{
    public class CompanyEntity
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public IEnumerable<EmployeeEntity> Employees { get; set; }
        public IEnumerable<IntervieweeEntity> Interviewees { get; set; }
    }
}
