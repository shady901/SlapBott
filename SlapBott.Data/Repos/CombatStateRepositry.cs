
using Microsoft.EntityFrameworkCore;
using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;
using System.Text.RegularExpressions;

namespace SlapBott.Data.Repos
{
    public class CombatStateRepositry: Repo<CombatState>
    {
        public CombatStateRepositry(SlapbottDbContext dBContext) : base(dBContext) { }
        public CombatState GetCombatStateByID(int Id)
        {
            CombatState State = _dbContext.CombatStates
               .Include(x=>x.Characters)
                  .ThenInclude(x=>x.Character)
               .Include(x=>x.Enemies)
                  .ThenInclude(x => x.Enemy)
               .Include(x=>x.Turns)
                .ThenInclude(x=>x.AttackRecords)
               .FirstOrDefault(pc => pc.Id == Id);



            return State;
        }
        public CombatState GetCombatStateByChannelID(ulong Id)
        {

            CombatState State = null; //_dbContext.CombatStates.First(State => State.ChannelID == Id);

            return State;
        }
        public CombatState SaveCombatState(CombatState state)
        {
            AddOrUpdateState(state);
            _dbContext.SaveChanges();
            return state;
        }
        public void AddOrUpdateState(CombatState state)
        {
            var meth = _dbContext.CombatStates.Update;


            if (state.Id <= 0) // not in the database
            {
                meth = _dbContext.CombatStates.Add;
            }

            meth(state);

        }
    }
}
