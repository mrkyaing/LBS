using LMSystem.Utilities;
using System.ComponentModel.DataAnnotations;

namespace LMSystem.Models.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public string id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Ip { get; set; }= NetworkHelper.GetLocalIPAddress();
        public bool IsInActive { get; set; }
    }
}
