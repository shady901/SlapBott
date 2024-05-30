using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Services.Dtos;
using SlapBott.Services.Objects;

namespace SlapBott.Services.Implmentations
{
    public class CombatManager
    {
        private CombatStateService _combatStateService;
        private CombatStateDto? _state = new();
        private EnemyService? _enemyService;
        public CombatManager(CombatStateService combatStateService, EnemyService enemyService)
        {  
            _combatStateService = combatStateService;
            _enemyService = enemyService;
        }
       
        
        
       
      
        public void Turn<T>(int StateID, int TargetId, SkillDto skillDto, T? characterDto = null, T? enemyDto = null) where T : Target
        {
            //  GetStateById(StateID); // state for something not sure at this time

            //SelectTarget - Player or Enemy Object
            //GetSkillData
            //GetAttackerData
            //GetTargetData
            //Do Damage - calculate off both player data
            //ApplyEffects
            //SaveTarget
            //SaveTurn




            //end turn 
            // if its not a raid boss begin enemy turn 


            // SaveState();
        }
        
        //public int CalculateDamageOfSkill(PlayerCharacterDto character, Skill skill ) 
        //{
           
        //    //apply buffs and debuffs of the player when we have set themup


        //    // attack base dmg + stat for skill * elemental damage %
        //    int damage = character.CalculateBaseStatDamageFor(skill) + character.GetCombinedStat(StatType.AttackDamage);
        //    damage = damage * character.GetCombinedStat(skill.GetSkillStatTypeByElement());

        //    return damage;
            
        //}
        public int CalculateDamage<TSender, TReciever>(TSender sender, TReciever reciever, SkillDto usedSkill) where TSender : Target where TReciever : Target
        {
            //
            //EQUIPSTATS AND COMBAT EFFECTS NOT INCLUDED
            //
            int damage = 0;
            int PowerModifier;
            //physical elemental or chaos for calculating increases
            ElementalType ElementalType = usedSkill.ElementalType;
            
            switch (ElementalType)
            {
                case ElementalType.Physical:
                    PowerModifier = sender.Stats.PhysicalPower;
                    break;
                case ElementalType.Chaos:
                    PowerModifier = (int)((sender.Stats.SpellPower*0.5)+(sender.Stats.PhysicalPower*0.5));
                    break;
                default:
                    PowerModifier = sender.Stats.SpellPower;
                    break;
            }

           
            foreach (var item in usedSkill.StatTypeRatio)
            {
                damage += (int)(sender.Stats.stats[item.Key] * usedSkill.StatTypeRatio[item.Key]);
            }

           
            return damage*(1+(PowerModifier/100));
        
        }
        private int CalcAndApplyDamage<TSender,TReciever>(SkillDto UsedSkill, TSender sender , TReciever reciever) where TSender : Target where TReciever : Target
        {
            var dmg = CalculateDamage(sender, reciever, UsedSkill);
            dmg = ApplyDamage(reciever, dmg,UsedSkill.ElementalType);


            return dmg;
        }

        private int ApplyDamage<TReciever>(TReciever reciever, int dmg,ElementalType elementalType) where TReciever : Target
        {
           return reciever.ApplyDamage(dmg,elementalType);
        }

      

        public async Task<AttackResults<TSender,TReciever>> Attack<TSender, TReciever>(SkillDto usedSkillDto, TSender sender, TReciever reciever) where TSender : Target where TReciever : Target
        {
            AttackResults<TSender, TReciever> attackResults = new AttackResults<TSender,TReciever>(sender,reciever);
            attackResults.Dodged = CalcDodge(reciever.Stats.DodgeChance);
            if (attackResults.Dodged == false)
            {
                attackResults.Damage = CalcAndApplyDamage(usedSkillDto, sender, reciever);
            }
            attackResults.Skill = usedSkillDto;
            return attackResults;
        }

        private bool CalcDodge(int dodgeChance)
        {
            Random r = new Random();

            // Generate a random number between 0 and 99 inclusive.
            int roll = r.Next(1, 101);

            // If the roll is less than the dodge chance, a dodge occurs.
            return roll < dodgeChance;
        }
    }
}
