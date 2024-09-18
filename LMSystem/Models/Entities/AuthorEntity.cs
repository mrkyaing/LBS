using System.ComponentModel.DataAnnotations.Schema;

namespace LMSystem.Models.Entities
{
    [Table("Author")]
    public class AuthorEntity : BaseEntity
    {

        public string Name { get; set; }
        public string Biography { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
    }
}
