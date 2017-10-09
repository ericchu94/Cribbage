using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Cribbage.Models;

namespace Cribbage.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly CribbageContext context;

        public GamesController(CribbageContext context)
        {
            this.context = context;
        }

        // GET api/games
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Games);
        }

        // GET api/games/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var game = context.Games.Find(id);
            if (game == null)
                return NotFound();
            return Ok(game);
        }

        // POST api/games
        [HttpPost]
        public Game Post()
        {
            var game = new Game();
            context.Games.Add(game);
            context.SaveChanges();
            return game;
        }

        // DELETE api/games/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var game = context.Games.Find(id);
            if (game == null)
                return NotFound();
            context.Games.Remove(game);
            context.SaveChanges();
            return Ok();
        }
    }
}
