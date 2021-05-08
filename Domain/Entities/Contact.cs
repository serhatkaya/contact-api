using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Contacts", Schema = "Application")]
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string ContactGroupId { get; set; }
        public ContactGroup ContactGroup { get; set; }
    }
}
