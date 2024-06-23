using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCheck.Entity.Entities
{
    [Table("role")]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
