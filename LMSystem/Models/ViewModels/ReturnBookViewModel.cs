using LMSystem.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSystem.Models.ViewModels
{
    public class ReturnBookViewModel
    {

        public string BookInfo { get; set; }

        public string MemberInfo { get; set; }
        public string IssueDate { get; set; }
        public string DueDate { get; set; }
        public string ReturnDate { get; set; }
        public string Status { get; set; }
        public decimal Issuefees { get; set; }
    }
}
