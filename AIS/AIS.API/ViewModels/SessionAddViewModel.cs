﻿using System;

namespace AIS.API.ViewModels
{
    public class SessionAddViewModel
    {
        public DateTime StartTime { get; set; }
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public int IntervieweeId { get; set; }
        public int QuestionAreaId { get; set; }
    }
}