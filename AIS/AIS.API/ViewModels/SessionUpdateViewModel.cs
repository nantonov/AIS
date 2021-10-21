using System;
using AIS.BLL.Models;

namespace AIS.API.ViewModels
{
    public class SessionUpdateViewModel
    {
        public DateTime StartTime { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int EmployeeId { get; set; }
        public int IntervieweeId { get; set; }
        public Interviewee Interviewee { get; set; }
        public int QuestionAreaId { get; set; }
    }
}