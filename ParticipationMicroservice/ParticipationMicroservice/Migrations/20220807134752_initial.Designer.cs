﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParticipationMicroservice.DBContexts;

namespace ParticipationMicroservice.Migrations
{
    [DbContext(typeof(ParticipationContext))]
    [Migration("20220807134752_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParticipationMicroservice.Model.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfSlots")
                        .HasColumnType("int");

                    b.Property<int>("SportId")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("SportId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ParticipationMicroservice.Model.Participation", b =>
                {
                    b.Property<int>("ParticipationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ParticipationId");

                    b.HasIndex("EventId");

                    b.ToTable("Participations");
                });

            modelBuilder.Entity("ParticipationMicroservice.Model.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int?>("ParticipationId")
                        .HasColumnType("int");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SportId")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("ParticipationId");

                    b.HasIndex("SportId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ParticipationMicroservice.Model.Sport", b =>
                {
                    b.Property<int>("SportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NoOfPlayers")
                        .HasColumnType("int");

                    b.Property<string>("SportName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sportType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SportId");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("ParticipationMicroservice.Model.Event", b =>
                {
                    b.HasOne("ParticipationMicroservice.Model.Sport", "Sports")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParticipationMicroservice.Model.Participation", b =>
                {
                    b.HasOne("ParticipationMicroservice.Model.Event", "Events")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParticipationMicroservice.Model.Player", b =>
                {
                    b.HasOne("ParticipationMicroservice.Model.Participation", null)
                        .WithMany("Player")
                        .HasForeignKey("ParticipationId");

                    b.HasOne("ParticipationMicroservice.Model.Sport", "Sports")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
