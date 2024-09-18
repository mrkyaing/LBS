using System.ComponentModel.DataAnnotations.Schema;

namespace LMSystem.Models.Entities
{
    [Table("Publisher")]
    public class PublisherEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string ContactInfo{ get; set; }

    }
}
