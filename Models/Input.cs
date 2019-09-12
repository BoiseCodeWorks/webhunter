using webhunt.Interfaces;

namespace webhunt.Models
{
  public class Input : IInput
  {
    public string Command { get; set; }
    public string Options { get; set; }

  }
}