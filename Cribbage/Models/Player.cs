namespace Cribbage.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public int Score { get; set; }
        public bool Go { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}