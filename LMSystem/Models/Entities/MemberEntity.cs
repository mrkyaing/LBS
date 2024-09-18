using System.ComponentModel.DataAnnotations.Schema;

namespace LMSystem.Models.Entities
{
    [Table("Member")]
    public class MemberEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Adress { get; set; }
        public DateTime MembershipDate { get; set; }
        public string MembershipType { get; set; }
    }
}
