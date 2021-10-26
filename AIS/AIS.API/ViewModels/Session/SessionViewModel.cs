using System;

namespace AIS.API.ViewModels.Session
{
    public class SessionViewModel
    {
        public int Id { get; set; }
        public DateTime StartedAt { get; set; }
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public int IntervieweeId { get; set; }
    }
}