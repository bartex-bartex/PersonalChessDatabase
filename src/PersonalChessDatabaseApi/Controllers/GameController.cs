using Microsoft.AspNetCore.Mvc;
using PersonalChessdatabaseLibrary;
using PersonalChessdatabaseLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalChessDatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // GET: api/<GameController>
        [HttpGet]
        public List<GameModel> Get()
        {
            List<GameModel> games = GlobalConfig.Connection.GetGame_All();

            return games;
        }

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public GameModel Get(int id)
        {
            GameModel game = GlobalConfig.Connection.GetGame(id);

            return game;
        }

        // POST api/<GameController>
        [HttpPost]
        public void Post([FromBody] GameModel value)
        {
            GlobalConfig.Connection.CreateGame(value);
        }

        //// PUT api/<GameController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<GameController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
