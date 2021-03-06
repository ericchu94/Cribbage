﻿// <auto-generated />
using Cribbage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Cribbage.Migrations
{
    [DbContext(typeof(CribbageContext))]
    [Migration("20171008210641_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Cribbage.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
