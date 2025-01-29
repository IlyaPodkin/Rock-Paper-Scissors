using GrpcService.Data.SettingsDb;
using GrpcService.Models.ModelsDTO;
using GrpcService.Models;

namespace GrpcService.Data.Service
{
    public class GameTransactionService : IService<GameTransaction, GameTransactionDto>
    {
        protected readonly ApplicationContext _context;

        public GameTransactionService(ApplicationContext context)
        {
            _context = context;
        }

        public GameTransaction Create(GameTransaction gameTransaction)
        {
            _context.GameTransactions.Add(gameTransaction);
            _context.SaveChanges();
            return gameTransaction;
        }

        public bool Update(Guid id, GameTransactionDto gameTransactionDto)
        {
            var gameTransaction = _context.GameTransactions.Find(id);
            if (gameTransaction == null)
            {
                return false;
            }
            gameTransaction.SenderUserId = gameTransactionDto.SenderUserId;
            gameTransaction.ReseiverUserId = gameTransactionDto.ReseiverUserId;
            gameTransaction.TransactionDate = gameTransactionDto.TransactionDate;
            gameTransaction.Amount = gameTransactionDto.Amount;
            return true;
        }

        public bool Delete(Guid id)
        {
            var gameTransaction = _context.GameTransactions.Find(id);
            if (gameTransaction == null)
            {
                return false;
            }
            _context.GameTransactions.Remove(gameTransaction);
            _context.SaveChanges();
            return true;
        }

        public List<GameTransaction> Get() => _context.GameTransactions.ToList();

    }
}
