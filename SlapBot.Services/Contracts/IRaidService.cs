
using SlapBott.Data.Models;
using SlapBott.Services.Dtos;

namespace SlapBott.Services.Contracts
{
    public interface IRaidService
    {

       string JoinRaid(ulong userId, ulong channelId);

       string AttackRaid(CharacterDto character, Skill skill, int Target);

       bool IsValidTarget(string Target);
       void SetupState(ulong channelID);
       int GetEnemyIdByTarget(string target);
    }
}
