
using Microsoft.EntityFrameworkCore;
using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;
using System.Text.RegularExpressions;

namespace SlapBott.Data.Repos
{
    public class CombatStateRepositry
    {
        private SlapbottDbContext _dbContext { get; set; }

        public CombatStateRepositry(SlapbottDbContext dBContext)
        {
            _dbContext = dBContext;

        }
        public CombatState GetCombatStateByID(int Id)
        {
            CombatState State = _dbContext.CombatStates
               .Include(x => x.Characters)
               .Include(x=>x.Enemies)
               .Include(x=>x.Turns)
               .FirstOrDefault(pc => pc.Id == Id);



            return State;
        }
        public CombatState GetCombatStateByChannelID(ulong Id)
        {

            CombatState State = null; //_dbContext.CombatStates.First(State => State.ChannelID == Id);

            return State;
        }
        public void SaveCombatState(CombatState state)
        {
            AddOrUpdateState(state);
            _dbContext.SaveChanges();
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
