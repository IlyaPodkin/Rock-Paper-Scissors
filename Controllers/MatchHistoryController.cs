using GrpcService.Data.Service;
using GrpcService.Data.SettingsDb;
using GrpcService.Models.ModelsDTO;
using GrpcService.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrpcService.Controllers
{
    public class MatchHistoryController : BaseController
    {
        private readonly MatchHistoryService _matchHistory;

        public MatchHistoryController(MatchHistoryService matchHistory, ApplicationContext context) => _matchHistory = matchHistory;

        [HttpPost("history")]
        public async Task<IActionResult> CreateMatchHistory([FromBody] MatchHistory matchHistory)
        {
            MatchHistory result = await _matchHistory.Create(matchHistory);
            if (result == null)
            {
                return BadRequest("Пользователь с таким id уже существует");
            }
            return Ok(result);
        }

        [HttpGet("history")]
        public async Task<IActionResult> Get() => Ok(await _matchHistory.Get());

        [HttpGet("history/{id}")]
        public async Task<IActionResult> GetMatchHistory(Guid id)
        {
            MatchHistory result = await _matchHistory.GetElement(id);
            if (result == null)
            {
                return NotFound("Такого пользователя не существует");
            }
            return Ok(result);
        }

        [HttpPut("history/{id}")]
        public async Task<IActionResult> UpdateMatchHistory([FromBody] MatchHistoryDto matchHistoryDto, Guid id)
        {
            bool result = await _matchHistory.Update(id, matchHistoryDto);
            if (result == false)
            {
                return NotFound("Такого пользователя не существует");
            }
            return Ok();
        }

        [HttpDelete("history/{id}")]
        public async Task<IActionResult> DeleteMatchHistory(Guid id)
        {
            bool result = await _matchHistory.Delete(id);
            if (result == false)
            {
                return NotFound("Такого пользователя не существует");
            }
            return Ok();
        }
    }
}
