using System.Collections.Generic;
using System.Linq;

using Cribbage.Models;

namespace Cribbage.Services
{
    public class GamesService : IGamesService
    {
        private readonly CribbageContext context;

        public GamesService(CribbageContext context)
        {
            this.context = context;
        }

        public IEnumerable<Game> GetGames() {
            return context.Games;
        }

        public Game GetGame(int id) {
            return context.Games.Find(id);
        }

        public Game CreateGame()
        {
            var game = new Game();
            context.Games.Add(game);
            context.SaveChanges();
            return game;
        }

        public bool DeleteGame(int id)
        {
            var game = context.Games.Find(id);
            if (game == null)
                return false;
            context.Games.Remove(game);
            context.SaveChanges();
            return true;
        }
    }
}
