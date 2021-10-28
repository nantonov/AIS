namespace AIS.BLL.Models
{
    public class Interviewee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AppliesFor { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
