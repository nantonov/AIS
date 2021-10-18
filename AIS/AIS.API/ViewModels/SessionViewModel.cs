using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIS.BLL.Models;

namespace AIS.API.ViewModels
{
    public class SessionViewModel
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int CompanyId { get; set; } 
        public Company _Company { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int IntervieweeId { get; set; }
        public Interviewee Interviewee { get; set; }
        public int QuestionAreaId { get; set; }
        // public QuestionArea QuestionArea { get; set; }
    }
}