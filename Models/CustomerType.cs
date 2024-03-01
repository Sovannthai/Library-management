using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class CustomerType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
