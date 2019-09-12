using System.Collections.Generic;

namespace webhunt.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        List<IItem> Inventory { get; set; }
    }
}