using System.ComponentModel.DataAnnotations;

namespace webhunt.Models
{
  public class User
  {
    [Required]
    [MinLength(5)]
    public string Name { get; set; }
  }
}