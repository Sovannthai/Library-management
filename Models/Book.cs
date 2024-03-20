using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string BookCode { get; set; }
        public string Description { get; set; } = null;
        [ForeignKey("Catelog")]
        public int CatelogId { get; set; }
        public virtual Catelog? Catelog { get; set; }
    }
}
