using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Cribbage.Models;
using Cribbage.Services;

namespace Cribbage.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly IGamesService gamesService;

        public GamesController(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        // GET api/games
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return gamesService.GetGames();
        }

        // GET api/games/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var game = gamesService.GetGame(id);
            if (game == null)
                return NotFound();
            return Ok(game);
        }

        // POST api/games
        [HttpPost]
        public Game Post()
        {
            return gamesService.CreateGame();
        }

        // DELETE api/games/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!gamesService.DeleteGame(id))
                return NotFound();
            return Ok();
        }
    }
}
