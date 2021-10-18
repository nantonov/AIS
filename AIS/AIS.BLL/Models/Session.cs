using System;
using AIS.BLL.Interfaces;

namespace AIS.BLL.Models
{
    public class Session : IHasIdBase
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public virtual int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public virtual int IntervieweeId { get; set; }
        public virtual Interviewee Interviewee { get; set; }
        public int QuestionAreaId { get; set; }
        // public QuestionArea QuestionArea { get; set; }
    }
}