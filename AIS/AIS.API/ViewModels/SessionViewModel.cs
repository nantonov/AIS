using System;

namespace AIS.API.ViewModels
{
    public class SessionViewModel
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int CompanyId { get; set; }
        public BLL.Models.Company Company { get; set; }
        public int EmployeeId { get; set; }
        public int IntervieweeId { get; set; }
        public BLL.Models.Interviewee Interviewee { get; set; }
        public int QuestionAreaId { get; set; }
    }
}