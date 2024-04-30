﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SlapBott.Data;

#nullable disable

namespace SlapBott.Data.Migrations
{
    [DbContext(typeof(SlapbottDbContext))]
    [Migration("20240429223812_Adding DiscordGuilds")]
    partial class AddingDiscordGuilds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("SlapBott.Data.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("CharExp")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClassId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CombatStateID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("InventoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LearnedSkillIds")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RaceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("RaceId");

                    b.HasIndex("StatsId")
                        .IsUnique();

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("SlapBott.Data.Models.CharacterClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BaseStats")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Name")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PerLevelStats")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CharacterClasses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BaseStats = "{\"Dexterity\":4,\"Strength\":4,\"Intelligence\":4,\"CritChance\":0,\"MaxHealth\":100,\"Health\":100,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":5,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0}",
                            Name = 1,
                            PerLevelStats = "{\"MaxHealth\":20,\"Strength\":1}"
                        },
                        new
                        {
                            Id = 2,
                            BaseStats = "{\"Dexterity\":4,\"Strength\":4,\"Intelligence\":4,\"CritChance\":0,\"MaxHealth\":100,\"Health\":100,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":5,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0}",
                            Name = 2,
                            PerLevelStats = "{\"SpellPower\":1,\"Intelligence\":1}"
                        });
                });

            modelBuilder.Entity("SlapBott.Data.Models.DiscordGuild", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConfiguredChannels")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<ulong>("GuildId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DiscordGuilds");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Enemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDead")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RegionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("RegionId");

                    b.ToTable("Enemies", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Enemy");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SlapBott.Data.Models.EnemyTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("LearnedSkillIds")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RaceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Stats")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("RaceId");

                    b.ToTable("EnemyTemplates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassId = 1,
                            Description = "a Pile of bones that has formed a silhouette of a Humanoid",
                            LearnedSkillIds = "[1]",
                            Name = "Skeleton Warrior",
                            RaceId = 5,
                            Stats = "{\"resistanceTypes\":[10,14,11,12,13],\"Id\":0,\"Character\":null,\"stats\":{\"Dexterity\":0,\"Strength\":0,\"Intelligence\":0,\"CritChance\":0,\"MaxHealth\":0,\"Health\":0,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":0,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0},\"Health\":0,\"MaxHealth\":0,\"Strength\":0,\"Dexterity\":0,\"Intelligence\":0,\"CritChance\":0,\"AttackDamage\":0,\"SpellPower\":0,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"ArmorRating\":0,\"DodgeChance\":0}"
                        });
                });

            modelBuilder.Entity("SlapBott.Data.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bag")
                        .HasColumnType("TEXT");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Equiped")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("SlapBott.Data.Models.PlayerCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("DiscordId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasLeveled")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsTemp")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RegistrationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.HasIndex("RegistrationId");

                    b.ToTable("PlayerCharacter");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BaseStats")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Name")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PerLevelStats")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Races");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BaseStats = "{\"Dexterity\":4,\"Strength\":4,\"Intelligence\":4,\"CritChance\":0,\"MaxHealth\":100,\"Health\":100,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":5,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0}",
                            Name = 1,
                            PerLevelStats = "{\"Dexterity\":1}"
                        },
                        new
                        {
                            Id = 2,
                            BaseStats = "{\"Dexterity\":4,\"Strength\":4,\"Intelligence\":4,\"CritChance\":0,\"MaxHealth\":100,\"Health\":100,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":5,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0}",
                            Name = 2,
                            PerLevelStats = "{\"MaxHealth\":20}"
                        },
                        new
                        {
                            Id = 5,
                            BaseStats = "{\"Dexterity\":4,\"Strength\":4,\"Intelligence\":4,\"CritChance\":0,\"MaxHealth\":100,\"Health\":100,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":5,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0}",
                            Name = 5,
                            PerLevelStats = "{\"MaxHealth\":20}"
                        });
                });

            modelBuilder.Entity("SlapBott.Data.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasActiveBoss")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RegionName")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isBossPending")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HasActiveBoss = false,
                            RegionName = 6,
                            isBossPending = false
                        },
                        new
                        {
                            Id = 2,
                            HasActiveBoss = false,
                            RegionName = 5,
                            isBossPending = false
                        },
                        new
                        {
                            Id = 3,
                            HasActiveBoss = false,
                            RegionName = 2,
                            isBossPending = false
                        },
                        new
                        {
                            Id = 4,
                            HasActiveBoss = false,
                            RegionName = 4,
                            isBossPending = false
                        },
                        new
                        {
                            Id = 5,
                            HasActiveBoss = false,
                            RegionName = 3,
                            isBossPending = false
                        },
                        new
                        {
                            Id = 6,
                            HasActiveBoss = false,
                            RegionName = 1,
                            isBossPending = false
                        });
                });

            modelBuilder.Entity("SlapBott.Data.Models.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ActiveCharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("DiscordId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActiveCharacterId");

                    b.ToTable("Registration", (string)null);
                });

            modelBuilder.Entity("SlapBott.Data.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("ElementalType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RequiredWeaponType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatTypeRatio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "You use All your force to create a Powerfull Strike",
                            ElementalType = 4,
                            Name = "Strike",
                            StatTypeRatio = "{\"Strength\":0.4,\"Dexterity\":0.3,\"Intelligence\":0.25}"
                        });
                });

            modelBuilder.Entity("SlapBott.Data.Models.Stats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("stats")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PlayersStats");
                });

            modelBuilder.Entity("SlapBott.Data.Models.TurnAttackRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TurnId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.HasIndex("TurnId");

                    b.ToTable("TurnAttackRecord");
                });

            modelBuilder.Entity("SlapBott.Services.Combat.Models.CombatState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("ChannelID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentTurnId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CombatStates");
                });

            modelBuilder.Entity("SlapBott.Services.Combat.Models.EnemyCombatState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CombatStateId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HadTurn")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CombatStateId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("EnemyCombatState");
                });

            modelBuilder.Entity("SlapBott.Services.Combat.Models.PlayerCharacterCombatState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CombatStateId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HadTurn")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CombatStateId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("PlayerCharacterCombatState");
                });

            modelBuilder.Entity("SlapBott.Services.Combat.Models.Turn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttackerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CombatStateId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TurnId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AttackerId");

                    b.HasIndex("TurnId", "CombatStateId");

                    b.ToTable("Turns");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Boss", b =>
                {
                    b.HasBaseType("SlapBott.Data.Models.Enemy");

                    b.HasDiscriminator().HasValue("Boss");
                });

            modelBuilder.Entity("SlapBott.Data.Models.RaidBoss", b =>
                {
                    b.HasBaseType("SlapBott.Data.Models.Boss");

                    b.HasDiscriminator().HasValue("RaidBoss");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Character", b =>
                {
                    b.HasOne("SlapBott.Data.Models.CharacterClass", "CharacterClass")
                        .WithMany("Character")
                        .HasForeignKey("ClassId");

                    b.HasOne("SlapBott.Data.Models.Race", "Race")
                        .WithMany("Character")
                        .HasForeignKey("RaceId");

                    b.HasOne("SlapBott.Data.Models.Stats", "Stats")
                        .WithOne("Character")
                        .HasForeignKey("SlapBott.Data.Models.Character", "StatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharacterClass");

                    b.Navigation("Race");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Enemy", b =>
                {
                    b.HasOne("SlapBott.Data.Models.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SlapBott.Data.Models.Region", "Region")
                        .WithMany("Enemies")
                        .HasForeignKey("RegionId");

                    b.Navigation("Character");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("SlapBott.Data.Models.EnemyTemplate", b =>
                {
                    b.HasOne("SlapBott.Data.Models.CharacterClass", "CharacterClass")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("SlapBott.Data.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId");

                    b.Navigation("CharacterClass");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Inventory", b =>
                {
                    b.HasOne("SlapBott.Data.Models.Character", "Character")
                        .WithOne("Inventory")
                        .HasForeignKey("SlapBott.Data.Models.Inventory", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("SlapBott.Data.Models.PlayerCharacter", b =>
                {
                    b.HasOne("SlapBott.Data.Models.Character", "Character")
                        .WithOne()
                        .HasForeignKey("SlapBott.Data.Models.PlayerCharacter", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SlapBott.Data.Models.Registration", "Registration")
                        .WithMany("PlayerCharacters")
                        .HasForeignKey("RegistrationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Registration");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Registration", b =>
                {
                    b.HasOne("SlapBott.Data.Models.PlayerCharacter", "Character")
                        .WithMany()
                        .HasForeignKey("ActiveCharacterId");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("SlapBott.Data.Models.TurnAttackRecord", b =>
                {
                    b.HasOne("SlapBott.Data.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SlapBott.Services.Combat.Models.Turn", "Turn")
                        .WithMany("AttackRecords")
                        .HasForeignKey("TurnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("Turn");
                });

            modelBuilder.Entity("SlapBott.Services.Combat.Models.EnemyCombatState", b =>
                {
                    b.HasOne("SlapBott.Services.Combat.Models.CombatState", "CombatState")
                        .WithMany("Enemies")
                        .HasForeignKey("CombatStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SlapBott.Data.Models.Enemy", "Enemy")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CombatState");

                    b.Navigation("Enemy");
                });

            modelBuilder.Entity("SlapBott.Services.Combat.Models.PlayerCharacterCombatState", b =>
                {
                    b.HasOne("SlapBott.Services.Combat.Models.CombatState", "CombatState")
                        .WithMany("Characters")
                        .HasForeignKey("CombatStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SlapBott.Data.Models.PlayerCharacter", "Character")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("CombatState");
                });

            modelBuilder.Entity("SlapBott.Services.Combat.Models.Turn", b =>
                {
                    b.HasOne("SlapBott.Data.Models.Character", "Attacker")
                        .WithMany()
                        .HasForeignKey("AttackerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SlapBott.Services.Combat.Models.CombatState", "CombatState")
                        .WithMany("Turns")
                        .HasForeignKey("TurnId", "CombatStateId")
                        .HasPrincipalKey("CurrentTurnId", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attacker");

                    b.Navigation("CombatState");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Character", b =>
                {
                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("SlapBott.Data.Models.CharacterClass", b =>
                {
                    b.Navigation("Character");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Race", b =>
                {
                    b.Navigation("Character");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Region", b =>
                {
                    b.Navigation("Enemies");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Registration", b =>
                {
                    b.Navigation("PlayerCharacters");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Stats", b =>
                {
                    b.Navigation("Character")
                        .IsRequired();
                });

            modelBuilder.Entity("SlapBott.Services.Combat.Models.CombatState", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Enemies");

                    b.Navigation("Turns");
                });

            modelBuilder.Entity("SlapBott.Services.Combat.Models.Turn", b =>
                {
                    b.Navigation("AttackRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
