using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Combat.Models
{

    public class CombatStateCharacter
    {

        public int Id;
        public int CombatStateId;
        public int CharacterId;
        public bool IsActive;

        [ForeignKey("CharacterId")]
        public virtual Character Character { get; set; }

        [ForeignKey("CombatStateId")]
        public virtual CombatState CombatState { get; set; }

    }

    public class CombatState
    {

        public int Id { get; set; }
        public ulong ChannelID { get; set; }

        public int CurrentTurnId { get; set; }

        //private ICollection<CombatStateCharacter> _enemies { get; set; } //this will have 1 or n number of enemy characters



        [ForeignKey("CurrentTurnId,Id")] 
        public ICollection<Turn> Turns { get; set; }

        //public ICollection<CombatStateCharacter> Characters { get; set; } // this will have active and non active Characters in it
        //public ICollection<CombatStateCharacter> Enemies { get => _enemies.Where(x=> x.Character is Enemy).ToList(); set => _enemies.Add((CombatStateCharacter)value); } //this will have 1 or n number of enemy characters        
        public CombatState() 
        {

        }


    }
}
