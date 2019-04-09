namespace TicTacToe
{
    public class Game 
    {
        public IPlayer MyPlayer  { get; set; }
        public IPlayer MyEngine { get; set; }
        public bool Over { get; set; }
        public bool Draw { get; set; }
        public string Id { get; set; }

        public Game(IPlayer _Player, IPlayer _Engine)
        {
          MyPlayer = _Player;
          MyEngine = _Engine;
        }
    }
}
