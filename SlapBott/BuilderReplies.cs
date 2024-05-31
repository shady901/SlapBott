using Discord;
using SlapBott.CommandsEnum;
using SlapBott.Data.Enums;
using SlapBott.Enums;
using SlapBott.ItemProject.Items;
using SlapBott.Services.Contracts;
using SlapBott.Services.Dtos;
using SlapBott.Services.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott
{
    public static class BuilderReplies
    {



        public static Embed RaceSelectedReply(string race)
        {
            Embed embed = new EmbedBuilder()
           .WithTitle($"You Have Selected {race}, Please Now Select a Class")
           .WithDescription("Warrior:Bonus Attacks in Melee + 1 Str Per level \n Mage: Bonuses Elemental Damage + 1 Int Per level")
           .Build();

            return embed;
        
        }
        public static Embed ClassSelectedReply(string Class)
        {
            Embed embed = new EmbedBuilder()
           .WithTitle($"You Have Selected {Class}")
           .WithDescription("U will Now Be Prompted To Assign Your Name")
           .Build();

            return embed;

        }
        public static Embed ChoseRaceEmbed()
        {
            Embed embed = new EmbedBuilder()
             .WithTitle("Chose Your Race")
             .WithDescription("Elf: Bonus to Dexterity(example)\n Human: Bonuses to Health and Armor")
             .Build();
            return embed;
        }
        public static Embed ReplyCreatedCompleteEmbed(string name,string description,string race,string cClass)
        {
            Embed embed = new EmbedBuilder()
             .WithTitle("Character Created")
             .WithDescription($"Name: {name} \n Description: {description} \n Race: {race}\n Class: {cClass}")
             .WithColor(Color.Green)
             .Build();
            return embed;
        }
        public static MessageComponent GetChoseRaceMessageComponent()
        {
            var em = new SelectMenuBuilder()
            .WithPlaceholder("Select An option")
            .WithCustomId(SelectMenuCommands.AssigningRace.ToString())
            .WithMinValues(1)
            .WithMaxValues(1)
            .AddOption("Elf", Races.Elf.ToString(), "Bonus Dex")
            .AddOption("Human", Races.Human.ToString(), "Bonus Health and Armor");

            var builder = new ComponentBuilder()
             .WithSelectMenu(em)
             .Build();

            return builder;
        }
        public static MessageComponent GetChoseClassMessageComponent()
        {
            var em = new SelectMenuBuilder()
            .WithPlaceholder("Select An option")
            .WithCustomId(SelectMenuCommands.AssignClass.ToString())
            .WithMinValues(1)
            .WithMaxValues(1)
            .AddOption("Warrior", Classes.Warrior.ToString(), "Bonus Attacks in Melee + 1 Str Per level")
            .AddOption("Mage", Classes.Mage.ToString(), "Bonuses Elemental Damage + 1 Int Per level");
            var builder = new ComponentBuilder()
             .WithSelectMenu(em)
             .Build();

            return builder;
        }


        public static Modal ModalCharacterNameDescription()
        {
            var builder = new ModalBuilder()

            .WithTitle("Give Your Character A Name")
            .WithCustomId("createcharacter_namedescription")
            .AddTextInput("Name?", "character_name", placeholder: "Luca")
            .AddTextInput("Describe Your Character?", "character_description", TextInputStyle.Paragraph,
            "rusic high elf with dark blue eyes and long green hair")
             .Build();
          return builder;
        }

        public static Embed DisplayWeapon(Weapon weapon)
        {
            string Affixes= string.Empty;
            foreach (var affix in weapon.itemAffixes)
            {
                Affixes += $"{Enum.GetName(affix.StatType)}: {affix.StatValue}\n";
            }

            Embed embed = new EmbedBuilder()
               .WithTitle($"{weapon.Name}")
               .WithDescription($"Damage: {weapon.Damage}\nSlotType: {weapon.EquipType}\nILevel:{weapon.ItemLevel}\nAccuracy: {weapon.Accuracy}\nAttackSpeed:{weapon.AttackSpeed}\nAffixes:\n{Affixes}\nRarety: {weapon.itemRarety}")
                 .WithFooter("Seed:" + weapon.Seed)
               .Build();
            return embed;
        }
        public static Embed DisplayArmor(Armor armor)
        {
            string Affixes = string.Empty;
            foreach (var affix in armor.itemAffixes)
            {
                Affixes += $"{Enum.GetName(affix.StatType)}: {affix.StatValue}\n";
            }
           
            Embed embed = new EmbedBuilder()
               .WithTitle($"{armor.Name}")
               .WithDescription($"Armor: {armor.ArmorStat}\nEvasion: {armor.EvasonStat}\nAttackSpeedModifier: {armor.WeaponAttackSpeedModifer} \nSlotType: {armor.EquipType}\nClass: {armor.Weight}\nILevel: {armor.ItemLevel}\nAffixes:\n{Affixes}\nRarety: {armor.itemRarety}")
               .WithFooter("Seed:"+armor.Seed)
               .Build();
            return embed;
        }
       
      
        public static Embed EmbedObject(DisplayDto DisplayObject) 
        {
            var embed = new EmbedBuilder()
             .WithTitle($"{DisplayObject.Name ?? "BossNameDisplayIssue"}")
             .WithDescription($"{DisplayObject.Description}")
             .WithFooter("");


            return embed.Build();
        }
        public static Embed DisplayCharacterObjectSheet<T>(T DisplayObject) where T : IDisplayable
        {
            var embed = new EmbedBuilder()
             .WithTitle($"{DisplayObject.Name ?? "BossNameDisplayIssue"}")
             .WithDescription($"{DisplayObject.Description}")
             .WithFooter($"FooterText");


            return embed.Build();
        }
        public static ButtonBuilder JoinRaidButton(int id)
        {
            ButtonBuilder myButton = new ButtonBuilder();
            myButton.WithCustomId(ButtonCustomIds.JoinRaid.ToString()+$" {id}");
            myButton.WithStyle(ButtonStyle.Danger);
            myButton.WithLabel("Join Raid Boss");
            return myButton;
        }
        public static MessageComponent CreateSkillsDropDown(List<SkillDto> skills, int EnemyCustomId, SelectMenuCommands selectMenuCommand)
        {
            var em = new SelectMenuBuilder()
            .WithPlaceholder("Select A Skill You Would like To Use")
            .WithCustomId(selectMenuCommand.ToString() + $" {EnemyCustomId}")
            .WithMinValues(1)
            .WithMaxValues(1);
           foreach (var skill in skills)
            {
                em.AddOption(skill.Name,skill.Id.ToString(),skill.Description);
            }
            var builder = new ComponentBuilder()
             .WithSelectMenu(em)
             .Build();

            return builder;
        }

        //needs to change doesnt display enough 
        public static Embed EmbedTurnResults(AttackResults<PlayerCharacterDto, EnemyDto> result, EnemyDto enemyDto, AttackResults<EnemyDto, PlayerCharacterDto>? enemyAttackResult = null)
        {   
            
            string description = $"{result.Sender.Name}\nUsed Skill: {result.Skill.Name}\nDamageType: {result.Skill.ElementalType}\nDamage Done: {result.Damage}";
            if (enemyAttackResult != null)
            {

                description += $"\n\n{enemyAttackResult.Sender.Name} Has Attacked Back\nUsed Skill: {enemyAttackResult.Skill.Name}\nDamageType: {enemyAttackResult.Skill.ElementalType}\nDamage Done: {enemyAttackResult.Damage}";
            }
            var embed = new EmbedBuilder()
             .WithTitle($"{result.Sender.Name} Attacked {result.Receiver.Name}")

             .WithDescription(description);
            

            return embed.Build();
        }
       
    }
}
