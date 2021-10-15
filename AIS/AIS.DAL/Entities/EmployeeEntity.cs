namespace AIS.DAL.Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; }
    }
}