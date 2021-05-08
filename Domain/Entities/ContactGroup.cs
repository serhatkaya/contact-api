using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("ContactGroups", Schema = "Application")]
    public class ContactGroup : BaseEntity
    {
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
