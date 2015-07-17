using System.Collections.Generic;
using Data.Models;

namespace Data.Repositories.Interfaces
{
    public interface IRaceLoader
    {
        IEnumerable<Race> GetRaces();
        Race GetRaceByName(string name);
    }
}
