using System.Collections.Generic;
using webhunt.Interfaces;

namespace webhunt.Models
{
  public class Player : IPlayer
  {
    public string Name { get; set; }
    public List<IItem> Inventory { get; set; }

    public Player(string name)
    {
        Name = name;
        Inventory = new List<IItem>();
    }
  }
}