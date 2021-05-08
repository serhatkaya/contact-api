using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Users", Schema = "Authentication")]
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
