using Microsoft.AspNetCore.Mvc;
using PersonalChessdatabaseLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalChessDatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // GET: api/<GameController>
        [HttpGet]
        public async Task<IActionResult> GetGames(IGameData data)
        {
            try
            {
                var results = await data.GetGames();
                if (!results.Any()) return NotFound();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id, IGameData data)
        {
            try
            {
                var results = await data.GetGame(id);
                if (results == null) return NotFound();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //// POST api/<GameController>
        [HttpPost]
        public async Task<IActionResult> InsertGame(GameModel game, IGameData data)
        {
            try
            {
                await data.InsertGame(game);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //// PUT api/<GameController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateUser(GameModel game, IGameData data)
        {
            try
            {
                await data.UpdateGame(game);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //// DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id, IGameData data)
        {
            try
            {
                await data.DeleteGame(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
