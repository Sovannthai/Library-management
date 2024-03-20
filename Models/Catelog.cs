using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Catelog
    {
        [Key]
        public int Id { get; set; }
        public string CatalogCode { get; set; }
        public string CatalogName { get; set; }
        public string ISBN { get; set; }
        public string AuthorName { get; set; }
        public string Publisher { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublicYear { get; set; }
        public string PublicEdition { get; set; }
    }
}
