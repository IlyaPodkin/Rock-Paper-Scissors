namespace GrpcService.Models
{
    public class GameTransaction
    {
        public Guid Id { get; set; }
        public Guid SenderUserId { get; set; }
        public Guid ReseiverUserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
