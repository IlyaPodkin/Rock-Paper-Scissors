namespace GrpcService.Models.ModelsDTO
{
    public class GameTransactionDto
    {
        public Guid SenderUserId { get; set; }
        public Guid ReseiverUserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
