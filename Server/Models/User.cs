namespace GrpcService.Models
{
    public class User
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
