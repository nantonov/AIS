﻿using System;
using AIS.BLL.Interfaces;

namespace AIS.BLL.Models
{
    public class Session : IHasIdBase
    {
        public int Id { get; set; }
        public DateTime StartedAt { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Interviewee Interviewee { get; set; }
        public int IntervieweeId { get; set; }
        public DateTime FinishedAt { get; set; }
    }
}