using System.Collections.Generic;
using webhunt.Interfaces;

namespace webhunt.Models
{
  public class GameService : IGameService
  {
    public Dictionary<string, IGame> Games { get; set; } = new Dictionary<string, IGame>();

    public IGame FindGameById(string id)
    {
      Games.TryGetValue(id, out IGame game);
      return game;
    }

    public IGame CreateGame(string playerName)
    {
      var game = new Game(playerName);
      Games.Add(game.Id, game);
      return game;
    }

  }

}