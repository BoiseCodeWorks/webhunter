using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webhunt.Interfaces;
using webhunt.Models;

namespace webhunt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameService _gs;

        // GET api/games
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            if (_gs.Games.Count < 1)
            {
                return BadRequest("No Games Found");
            }
            return Ok(_gs.Games.Keys);
        }

        // GET api/games/guid
        [HttpGet("{id}")]
        public ActionResult<IGame> Get(string id)
        {
            var game = _gs.FindGameById(id);
            if (game == null)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(game);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<IGame> Post([FromBody] User user)
        {
            return Ok(_gs.CreateGame(user.Name));
        }

        // PUT api/games/gameId
        [HttpPut("{id}")]
        public ActionResult<IGame> Put(string id, [FromBody] Input userInput)
        {
            try
            {

                var game = _gs.FindGameById(id);
                if (game == null)
                {
                    return BadRequest("Invalid Id");
                }
                game.ProcessInput(userInput);
                return Ok(game);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) { }

        public GamesController(GameService gs)
        {
            _gs = gs;
        }

    }
}