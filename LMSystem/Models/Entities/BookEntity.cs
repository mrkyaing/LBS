using System.ComponentModel.DataAnnotations.Schema;

namespace LMSystem.Models.Entities
{
    public class BookEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Categoryid { get; set; }
        [ForeignKey("Categoryid")]
        public virtual CategoryEntity Category { get; set; }
        public string Authorid { get; set; }
        [ForeignKey("Authorid")]
        public virtual AuthorEntity Author { get; set; }
        public string Publisherid { get; set; }
        [ForeignKey("Publisherid")]
        public virtual PublisherEntity Publisher { get; set; }
        public int PublicationYear { get; set; }
        private int numberOfCopies;

        public int NumberOfCopies
        {
            get { return numberOfCopies; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                numberOfCopies = value;
            }
        }

        public string language { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string ISBN { get; set; }
        public decimal UnitPrice { get; set; }



    }
}
