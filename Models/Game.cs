using System;
using webhunt.Interfaces;

namespace webhunt.Models
{
  public class Game : IGame
  {
    public string Id { get; set; }
    public IPlayer Player { get; set; }
    public IRoom CurrentRoom { get; set; }

    public void ProcessInput(IInput input)
    {
      switch (input.Command)
      {
        case "go":
          Go(input.Options);
          break;
        case "take":
          Take(input.Options);
          break;
      }
    }

    private void Take(string options) { }

    private void Go(string direction)
    {
      CurrentRoom.Exits.TryGetValue(direction, out IRoom nextRoom);
      if (nextRoom == null) { return; }
      CurrentRoom = nextRoom;
    }

    private void Setup()
    {
      var room1 = new Room("Room 1", "It's where we start");
      var room2 = new Room("Room 2", "It's mostly a hallway");
      var room3 = new Room("Room 3", "You win or Lose here");

      room1.AddExit(room2, "north");
      room2.AddExit(room1, "south");

      room2.AddExit(room3, "west");
      room3.AddExit(room2, "east");
      CurrentRoom = room1;
    }

    public Game(string playerName)
    {
      Id = Guid.NewGuid().ToString();
      Player = new Player(playerName);
      Setup();
    }
  }
}