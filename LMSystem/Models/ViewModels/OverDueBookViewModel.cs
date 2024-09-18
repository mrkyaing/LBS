namespace LMSystem.Models.ViewModels
{
    public class OverDueBookViewModel
    {
      
       

        public string BookName { get; set; }
        public decimal BookUnitPrice { get; set; }
        public string AuthorName { get; set; }
        public string MemberName { get; set; }
        public string MemberPhone { get; set; }
        public string MemberAdress { get; set; }
        public string IssueDate { get; set; }
        public string DueDate { get; set; }
    }
}
