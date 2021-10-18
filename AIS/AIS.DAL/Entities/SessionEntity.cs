using System;

namespace AIS.DAL.Entities
{
    public class SessionEntity
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }
        public int IntervieweeId { get; set; }
        public IntervieweeEntity Interviewee { get; set; }
        public int QuestionAreaId { get; set; }
        // public QuestionArea QuestionArea { get; set; }
    }
}