using LMSystem.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSystem.Models.ViewModels
{
    public class BookViewModel
    {
        public string id { get; set; }
        public string Title { get; set; }
        public string Categoryid { get; set; } 
        public string Authorid { get; set; } 
        public string Publisherid { get; set; }
        public string CategoryInfo { get; set; }
        public string AuthorInfo { get; set; }
        public string PublisherInfo { get; set; }
        public int PublicationYear { get; set; }
        public int NumberOfCopies { get; set; }
        public string language { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string ISBN { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
