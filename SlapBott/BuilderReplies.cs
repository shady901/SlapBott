using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static Embed GetChoseRaceEmbed()
        {
            Embed embed = new EmbedBuilder()
             .WithTitle("Chose Your Race")
             .WithDescription("Elf: Bonus to Dexterity(example)\n Human: Bonuses to Health and Armor")
             .Build();
            return embed;
        }
        public static MessageComponent GetChoseRaceMessageComponent()
        {
            var em = new SelectMenuBuilder()
            .WithPlaceholder("Select An option")
            .WithCustomId("createcharacter_selectrace")
            .WithMinValues(1)
            .WithMaxValues(1)
            .AddOption("Elf", "Elf", "Bonus Dex")
            .AddOption("Human", "Human", "Bonus Health and Armor");

            var builder = new ComponentBuilder()
             .WithSelectMenu(em)
             .Build();

            return builder;
        }
    }
}
