using AIS.API.ViewModels.Company;

namespace AIS.API.ViewModels.Interviewee
{
    public class IntervieweeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AppliesFor { get; set; }
        public int CompanyId { get; set; }
        public ShortCompanyViewModel Company { get; set; }
    }
}
