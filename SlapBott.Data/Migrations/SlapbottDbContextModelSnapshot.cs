﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Slappbott.Data;

#nullable disable

namespace SlapBott.Data.Migrations
{
    [DbContext(typeof(SlapbottDbContext))]
    partial class SlapbottDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("SlapBott.Data.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiscordID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DiscordID");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ActiveCharacter")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("DiscordId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActiveCharacter");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Character", b =>
                {
                    b.HasOne("SlapBott.Data.Models.Registration", "Registration")
                        .WithMany("UserCharacters")
                        .HasForeignKey("DiscordID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Registration");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Registration", b =>
                {
                    b.HasOne("SlapBott.Data.Models.Character", "Character")
                        .WithMany()
                        .HasForeignKey("ActiveCharacter");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("SlapBott.Data.Models.Registration", b =>
                {
                    b.Navigation("UserCharacters");
                });
#pragma warning restore 612, 618
        }
    }
}
