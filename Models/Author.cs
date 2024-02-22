namespace EmpManagement.Models
{
    public class Author
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public string gender { get; set; }
        public DateTime Dob {  get; set; }
        public string Address { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
