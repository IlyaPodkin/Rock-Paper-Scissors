using GrpcService.Data.SettingsDb;
using GrpcService.Models.ModelsDTO;
using GrpcService.Models;
using Microsoft.EntityFrameworkCore;

namespace GrpcService.Data.Service
{
    public class GameTransactionService : IService<GameTransaction, GameTransactionDto>
    {
        protected readonly ApplicationContext _context;

        public GameTransactionService(ApplicationContext context) => _context = context;
        
        public async Task<GameTransaction> Create(GameTransaction gameTransaction)
        {
            await _context.GameTransactions.AddAsync(gameTransaction);
            await _context.SaveChangesAsync();
            return gameTransaction;
        }

        public async Task<bool> Update(Guid id, GameTransactionDto gameTransactionDto)
        {
            var gameTransaction = await _context.GameTransactions.FindAsync(id);
            if (gameTransaction == null)
            {
                return false;
            }
            gameTransaction.SenderUserId = gameTransactionDto.SenderUserId;
            gameTransaction.ReseiverUserId = gameTransactionDto.ReseiverUserId;
            gameTransaction.TransactionDate = gameTransactionDto.TransactionDate;
            gameTransaction.Amount = gameTransactionDto.Amount;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var gameTransaction = await _context.GameTransactions.FindAsync(id);
            if (gameTransaction == null)
            {
                return false;
            }
             _context.GameTransactions.Remove(gameTransaction);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GameTransaction>> Get() => await _context.GameTransactions.ToListAsync();
        public async Task<GameTransaction> GetElement(Guid id) => await _context.GameTransactions.FirstOrDefaultAsync(u => u.Id == id);
    }
}
