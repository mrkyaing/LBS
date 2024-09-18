namespace LMSystem.Models.ViewModels
{
    public class MemberViewModel
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Adress { get; set; }
        public DateTime MembershipDate { get; set; }
        public string MembershipType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
