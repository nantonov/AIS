using System;
using System.Collections.Generic;

namespace AIS.DAL.Entities
{
    public class SessionEntity
    {
        public int Id { get; set; }
        public DateTime StartedAt { get; set; }
        public int EmployeeId { get; set; }
        public virtual EmployeeEntity Employee { get; set; }
        public int IntervieweeId { get; set; }
        public virtual IntervieweeEntity Interviewee { get; set; }
        public DateTime FinishedAt { get; set; }
        public int QuestionAreaId { get; set; }
        public virtual QuestionAreaEntity QuestionArea { get; set; }
        public virtual ICollection<QuestionIntervieweeAnswerEntity> QuestionIntervieweeAnswers { get; set; }
    }
}