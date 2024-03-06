using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        public string? Pob { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        [ForeignKey("CustomerType")]
        public int CustomerTypeId { get; set; }
        public virtual CustomerType? CustomerType { get; set; }
    }
}
