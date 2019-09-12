using System.Collections.Generic;

namespace webhunt.Interfaces
{
  public interface IGameService
  {
    Dictionary<string, IGame> Games { get; set; }
  }

}