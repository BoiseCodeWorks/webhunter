using System.Collections.Generic;

namespace webhunt.Interfaces
{
    public interface IRoom
    {
        string Name { get; set; }
        string Description { get; set; }
        List<IItem> Items { get; set; }
        Dictionary<string, IRoom> Exits { get; set; }

        void AddExit(IRoom room, string direction);
    }
}