using System;

namespace AIS.DAL.Entities
{
    public class SessionEntity
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public virtual int CompanyId { get; set; }
        public virtual CompanyEntity Company { get; set; }
        public virtual int EmployeeId { get; set; }
        public virtual EmployeeEntity Employee { get; set; }
        public virtual int IntervieweeId { get; set; }
        public virtual IntervieweeEntity Interviewee { get; set; }
        public int QuestionAreaId { get; set; }
        // public QuestionArea QuestionArea { get; set; }
    }
}