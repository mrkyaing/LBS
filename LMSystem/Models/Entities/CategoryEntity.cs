using System.ComponentModel.DataAnnotations.Schema;

namespace LMSystem.Models.Entities
{
    [Table("Category")]
    public class CategoryEntity : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
