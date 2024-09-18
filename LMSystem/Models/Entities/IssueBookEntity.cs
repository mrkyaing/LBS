using System.ComponentModel.DataAnnotations.Schema;

namespace LMSystem.Models.Entities
{
    [Table("IssueBook")]
    public class IssueBookEntity:BaseEntity
    {
        public string Bookid { get; set; }
        [ForeignKey("Bookid")]
        public virtual BookEntity Book { get; set; }
        public string Memberid { get; set; }
        [ForeignKey("Memberid")]
        public virtual MemberEntity Member { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; }
        public decimal Issuefees { get; set; }
    }
}
