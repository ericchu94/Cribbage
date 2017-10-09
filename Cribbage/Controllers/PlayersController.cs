using Microsoft.AspNetCore.Mvc;

using Cribbage.Models;

namespace Cribbage.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly CribbageContext context;

        public PlayersController(CribbageContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Players);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var player = context.Players.Find(id);
            if (player == null)
                return NotFound();
            return Ok(player);
        }

        [HttpPost]
        public Player Post()
        {
            var player = new Player();
            context.Players.Add(player);
            context.SaveChanges();
            return player;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var player = context.Players.Find(id);
            if (player == null)
                return NotFound();
            context.Players.Remove(player);
            context.SaveChanges();
            return Ok();
        }
    }
}