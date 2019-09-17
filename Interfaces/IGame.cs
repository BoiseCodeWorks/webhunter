namespace webhunt.Interfaces
{
  public interface IGame
  {
    string Id { get; set; }
    IPlayer Player { get; set; }
    IRoom CurrentRoom { get; set; }
    string Message { get; set; }

    void ProcessInput(IInput input);
  }

}