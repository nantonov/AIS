using System.ComponentModel.DataAnnotations;

namespace AIS.DAL.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
