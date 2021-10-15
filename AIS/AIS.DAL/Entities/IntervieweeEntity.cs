namespace AIS.DAL.Entities
{
    public class IntervieweeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AppliesFor { get; set; }
        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; }
    }
}
