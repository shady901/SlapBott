using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public int CalculateDamage<TSender, TReciever>(TSender sender, TReciever reciever, SkillDto usedSkill, AttackResults<TSender, TReciever> attackResults) where TSender : Target where TReciever : Target
        {
            //
            //EQUIPSTATS AND COMBAT EFFECTS NOT INCLUDED
            //
            int damage = 0;
            int PowerModifier;
            double CritMulti =1;
            //physical elemental or chaos for calculating increases
            ElementalType ElementalType = usedSkill.ElementalType;

            if (attackResults.Crit)
            {
                CritMulti = 1.5;
            }
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


            return (int)(damage * (1 + (PowerModifier / 100))* CritMulti);
        
        }
        private AttackResults<TSender, TReciever> CalcAndApplyDamage<TSender,TReciever>(SkillDto UsedSkill, TSender sender , TReciever reciever, AttackResults<TSender,TReciever> attackResults) where TSender : Target where TReciever : Target
        {
            var dmg = CalculateDamage(sender, reciever, UsedSkill, attackResults);



            return ApplyDamage(reciever, dmg, UsedSkill.ElementalType, attackResults);
        }

        private AttackResults<TSender,TReciever> ApplyDamage<TSender,TReciever>(TReciever reciever, int dmg,ElementalType elementalType, AttackResults<TSender, TReciever> attackResults) where TReciever : Target where TSender :Target
        {
            reciever.ApplyDamage(dmg, elementalType, attackResults);
            return attackResults;
        }

      

        public async Task<AttackResults<TSender,TReciever>> Attack<TSender, TReciever>(SkillDto usedSkillDto, TSender sender, TReciever reciever) where TSender : Target where TReciever : Target
        {
            AttackResults<TSender, TReciever> attackResults = new AttackResults<TSender,TReciever>(sender,reciever);
            attackResults.Dodged = CalcDodge(reciever.Stats.DodgeChance);
            if (attackResults.Dodged == false)
            {
                if (CalcCrit(sender.Stats.CritChance))
                {
                    attackResults.Crit = true;
                }
                CalcAndApplyDamage<TSender,TReciever>(usedSkillDto, sender, reciever,attackResults);
            }
            attackResults.Skill = usedSkillDto;
            return attackResults;
        }

        private bool CalcDodge(int dodgeChance)
        {
            return RandomRoll100() < dodgeChance;
        }
        private bool CalcCrit(int critChance)
        {
            return RandomRoll100() < critChance;
        }
        private int RandomRoll100()
        {
            Random r = new Random();

            int roll = r.Next(1, 101);
            return roll;
        }
    }
}
