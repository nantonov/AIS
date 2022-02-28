using System;

namespace AIS.API.ViewModels.Session
{
    public class ShortSessionViewModel
    {
        public int Id { get; set; }
        public DateTime StartedAt { get; set; }
        public int EmployeeId { get; set; }
        public int IntervieweeId { get; set; }
        public DateTime FinishedAt { get; set; }
        public int QuestionAreaId { get; set; }
    }
}
