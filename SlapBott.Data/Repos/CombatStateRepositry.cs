
using SlapBott.Services.Combat.Models;

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

            CombatState State = null; // _dbContext.CombatStates.First(State => State.Id == Id);

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
            //var meth = _dbContext.CombatStates.Update;


            //if (state.Id <= 0) // not in the database
            //{
            //    meth = _dbContext.CombatStates.Add;
            //}

            //meth(state);

        }
    }
}
