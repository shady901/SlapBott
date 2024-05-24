using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Services.Dtos;

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
            int damage;
            int PowerModifier;
            //physical elemental or chaos for calculating increases
            StatType ElementalType =  usedSkill.GetSkillStatTypeByElement();
            
            switch (ElementalType)
            {
                case StatType.PhysicalDamage:
                    PowerModifier = sender.Stats.AttackDamage;
                    break;
                case StatType.ChaosDamage:
                    PowerModifier = (int)((sender.Stats.SpellPower*0.5)+(sender.Stats.AttackDamage*0.5));
                    break;
                default:
                    PowerModifier = sender.Stats.SpellPower;
                    break;
            }

            foreach (var item in usedSkill.StatTypeRatio)
            {
                damage =+ (int)(sender.Stats.stats[item.Key] * usedSkill.StatTypeRatio[item.Key]);
            }

            //
            //
            //
            return 0;
        
        }
        public int CalcAndApplyDamage<TSender,TReciever>(SkillDto UsedSkill, TSender sender , TReciever reciever) where TSender : Target where TReciever : Target
        {
            var dmg = CalculateDamage(sender, reciever, UsedSkill);
            dmg = ApplyDamage(reciever, dmg);


            return dmg;
        }

        private int ApplyDamage<TReciever>(TReciever reciever, int dmg) where TReciever : Target
        {
            throw new NotImplementedException();
        }

       
        public StatType GetStatTypeByElementalType(ElementalType elementalType)
        {
            switch (elementalType)
            {
              
                case ElementalType.Fire:
                    return StatType.FireResistance;
                case ElementalType.Frost:
                    return StatType.FrostResistance;
                case ElementalType.Lightning:
                    return StatType.LightningResistance;
                case ElementalType.Physical:
                    return StatType.PhysicalResistance;
                case ElementalType.Chaos:
                    return StatType.ChaosResistance;
                default:
                    return StatType.none;
            }
        }
       
    }
}
