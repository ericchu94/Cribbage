using System.Collections.Generic;
using System.Linq;

using Cribbage.Models;

namespace Cribbage.Services
{
    public interface IGamesService
    {
        IEnumerable<Game> GetGames();
        Game GetGame(int id);
        Game CreateGame();
        bool DeleteGame(int id);
    }
}
