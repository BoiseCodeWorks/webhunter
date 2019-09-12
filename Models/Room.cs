using System.Collections.Generic;
using webhunt.Interfaces;

namespace webhunt.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IItem> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    public void AddExit(IRoom room, string direction)
    {
      Exits.Add(direction, room);
    }

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<IItem>();
      Exits = new Dictionary<string, IRoom>();
    }
  }
}