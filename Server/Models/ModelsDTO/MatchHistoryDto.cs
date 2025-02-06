namespace GrpcService.Models.ModelsDTO
{
    public class MatchHistoryDto
    {
        public Guid FirstUserId { get; set; }
        public Guid SecondUserId { get; set; }
        public decimal BetAmount { get; set; }
        public Guid? WinnerId { get; set; }
        public DateTime MatchDate { get; set; }
        public string Status { get; set; }
    }
}
