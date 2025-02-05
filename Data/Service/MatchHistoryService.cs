using GrpcService.Data.SettingsDb;
using GrpcService.Models.ModelsDTO;
using GrpcService.Models;
using Microsoft.EntityFrameworkCore;

namespace GrpcService.Data.Service
{
    public class MatchHistoryService : IService<MatchHistory, MatchHistoryDto> 
    {
        protected readonly ApplicationContext _context;

        public MatchHistoryService(ApplicationContext context) => _context = context;

        public async Task<MatchHistory> Create(MatchHistory matchHistory)
        {
            await _context.History.AddAsync(matchHistory);
            await _context.SaveChangesAsync();
            return matchHistory;
        }

        public async Task<bool> Update(Guid id, MatchHistoryDto matchHistoryDto)
        {
            var matchHistory = await _context.History.FindAsync(id);
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
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var matchHistory = await _context.History.FindAsync(id);
            if (matchHistory == null)
            {
                return false;
            }
            _context.History.Remove(matchHistory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<MatchHistory>> Get() => await _context.History.ToListAsync();
        public async Task<MatchHistory> GetElement(Guid id) => await _context.History.FirstOrDefaultAsync(u => u.Id == id);
    }
}
