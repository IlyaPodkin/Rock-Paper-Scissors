using GrpcService.Data.SettingsDb;
using GrpcService.Models.ModelsDTO;
using GrpcService.Models;

namespace GrpcService.Data.Service
{
    public class MatchHistoryService
    {
        protected readonly ApplicationContext _context;

        public MatchHistoryService(ApplicationContext context)
        {
            _context = context;
        }

        public MatchHistory CreateMatchHistory(MatchHistory matchHistory)
        {
            _context.History.Add(matchHistory);
            _context.SaveChanges();
            return matchHistory;
        }

        public bool UpdateMatchHistory(Guid id, MatchHistoryDto matchHistoryDto)
        {
            var matchHistory = _context.History.Find(id);
            if (matchHistory == null)
            {
                return false;
            }
            matchHistory.FirstUserId = matchHistoryDto.FirstUserId;
            matchHistory.SecondUserId = matchHistoryDto.SecondUserId;
            matchHistory.MatchDate = matchHistoryDto.MatchDate;
            matchHistory.WinnerId = matchHistoryDto.WinnerId;
            matchHistory.BetAmount = matchHistoryDto.BetAmount;
            matchHistory.Status = matchHistoryDto.Status;
            return true;
        }

        public bool DeletematchHistory(Guid id)
        {
            var matchHistory = _context.History.Find(id);
            if (matchHistory == null)
            {
                return false;
            }
            _context.History.Remove(matchHistory);
            _context.SaveChanges();
            return true;
        }

        public List<MatchHistory> GetmatchHistorys() => _context.History.ToList();
    }
}
