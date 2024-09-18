using System.ComponentModel.DataAnnotations.Schema;

namespace LMSystem.Models.Entities
{
    [Table("Librarian")]
    public class LibrarianEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Userid { get; set; }

    }
}
