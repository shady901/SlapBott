using SlapBott.Data.Models;
using SlapBott.Services.Dtos;

namespace SlapBott.Services.Contracts
{
    public interface IDisplayable
    {
        string Name { get; }
        string Description { get; }        
        StatsDto? Stats { get; }
        ulong CharExp { get; set; }
        CharacterClassDto? CharacterClass { get;}
        List<int> Skills { get;}
        SubClassDto? SubClass { get;}

    }
}