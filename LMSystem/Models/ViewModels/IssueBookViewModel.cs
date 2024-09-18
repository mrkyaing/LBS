using LMSystem.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSystem.Models.ViewModels
{
    public class IssueBookViewModel 
    {
        public string Status { get; set; }
        public string id { get; set; }
        public string Bookid { get; set; }
        public  string ReturnDate { get; set; }
        public string BookInfo { get; set; }
        public string Memberid { get; set; }
        public string MemberInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Issuefees { get; set; }
    }
}
