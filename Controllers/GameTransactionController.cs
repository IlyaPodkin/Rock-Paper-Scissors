using GrpcService.Data.Service;
using GrpcService.Data.SettingsDb;
using GrpcService.Models.ModelsDTO;
using GrpcService.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrpcService.Controllers
{
    public class GameTransactionController : BaseController
    {
        private readonly GameTransactionService _gameTransaction;

        public GameTransactionController(GameTransactionService gameTransaction, ApplicationContext context) => _gameTransaction = gameTransaction;

        [HttpPost("transaction")]
        public async Task<IActionResult> CreateGameTransaction([FromBody] GameTransaction gameTransaction)
        {
            GameTransaction result = await _gameTransaction.Create(gameTransaction);
            if (result == null)
            {
                return BadRequest("Пользователь с таким id уже существует");
            }
            return Ok(result);
        }

        [HttpGet("transaction")]
        public async Task<IActionResult> Get() => Ok(await _gameTransaction.Get());

        [HttpGet("transaction/{id}")]
        public async Task<IActionResult> GetGameTransaction(Guid id)
        {
            GameTransaction result = await _gameTransaction.GetElement(id);
            if (result == null)
            {
                return NotFound("Такого пользователя не существует");
            }
            return Ok(result);
        }

        [HttpPut("transaction/{id}")]
        public async Task<IActionResult> UpdateGameTransaction([FromBody] GameTransactionDto gameTransactionDto, Guid id)
        {
            bool result = await _gameTransaction.Update(id, gameTransactionDto);
            if (result == false)
            {
                return NotFound("Такого пользователя не существует");
            }
            return Ok();
        }

        [HttpDelete("transaction/{id}")]
        public async Task<IActionResult> DeleteGameTransaction(Guid id)
        {
            bool result = await _gameTransaction.Delete(id);
            if (result == false)
            {
                return NotFound("Такого пользователя не существует");
            }
            return Ok();
        }
    }
}
