﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokerTime.Persistence;

namespace PokerTime.Persistence.Migrations
{
    [DbContext(typeof(ReturnDbContext))]
    [Migration("20191014200351_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PokerTime.Domain.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationTimestamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("LaneId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("RetrospectiveId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(2048)")
                        .HasMaxLength(2048);

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("LaneId");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("RetrospectiveId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("PokerTime.Domain.Entities.NoteGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LaneId")
                        .HasColumnType("int");

                    b.Property<int>("RetrospectiveId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("LaneId");

                    b.HasIndex("RetrospectiveId");

                    b.ToTable("NoteGroup");
                });

            modelBuilder.Entity("PokerTime.Domain.Entities.NoteLane", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("NoteLane");
                });

            modelBuilder.Entity("PokerTime.Domain.Entities.NoteVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NoteGroupId")
                        .HasColumnType("int");

                    b.Property<int?>("NoteId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("RetrospectiveId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NoteGroupId");

                    b.HasIndex("NoteId");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("RetrospectiveId");

                    b.ToTable("NoteVote");
                });

            modelBuilder.Entity("PokerTime.Domain.Entities.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsFacilitator")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("RetrospectiveId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RetrospectiveId");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("PokerTime.Domain.Entities.PredefinedParticipantColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("PredefinedParticipantColor");
                });

            modelBuilder.Entity("PokerTime.Domain.Entities.Retrospective", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationTimestamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("CurrentStage")
                        .HasColumnType("int");

                    b.Property<string>("HashedPassphrase")
                        .HasColumnType("char(64)")
                        .IsFixedLength(true)
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.Property<string>("FacilitatorHashedPassphrase")
                        .IsRequired()
                        .HasColumnType("char(64)")
                        .IsFixedLength(true)
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Retrospective");
                });

            modelBuilder.Entity("PokerTime.Domain.Entities.Note", b =>
                {
                    b.HasOne("PokerTime.Domain.Entities.NoteGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("PokerTime.Domain.Entities.NoteLane", "Lane")
                        .WithMany()
                        .HasForeignKey("LaneId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PokerTime.Domain.Entities.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PokerTime.Domain.Entities.Retrospective", "Retrospective")
                        .WithMany("Notes")
                        .HasForeignKey("RetrospectiveId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("PokerTime.Domain.Entities.NoteGroup", b =>
                {
                    b.HasOne("PokerTime.Domain.Entities.NoteLane", "Lane")
                        .WithMany()
                        .HasForeignKey("LaneId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PokerTime.Domain.Entities.Retrospective", "Retrospective")
                        .WithMany("NoteGroup")
                        .HasForeignKey("RetrospectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokerTime.Domain.Entities.NoteVote", b =>
                {
                    b.HasOne("PokerTime.Domain.Entities.NoteGroup", "NoteGroup")
                        .WithMany()
                        .HasForeignKey("NoteGroupId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("PokerTime.Domain.Entities.Note", "Note")
                        .WithMany()
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("PokerTime.Domain.Entities.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PokerTime.Domain.Entities.Retrospective", "Retrospective")
                        .WithMany("NoteVotes")
                        .HasForeignKey("RetrospectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokerTime.Domain.Entities.Participant", b =>
                {
                    b.HasOne("PokerTime.Domain.Entities.Retrospective", "Retrospective")
                        .WithMany("Participants")
                        .HasForeignKey("RetrospectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("PokerTime.Domain.ValueObjects.ParticipantColor", "Color", b1 =>
                        {
                            b1.Property<int>("ParticipantId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<byte>("B")
                                .HasColumnType("tinyint");

                            b1.Property<byte>("G")
                                .HasColumnType("tinyint");

                            b1.Property<byte>("R")
                                .HasColumnType("tinyint");

                            b1.HasKey("ParticipantId");

                            b1.ToTable("Participant");

                            b1.WithOwner()
                                .HasForeignKey("ParticipantId");
                        });
                });

            modelBuilder.Entity("PokerTime.Domain.Entities.PredefinedParticipantColor", b =>
                {
                    b.OwnsOne("PokerTime.Domain.ValueObjects.ParticipantColor", "Color", b1 =>
                        {
                            b1.Property<int>("PredefinedParticipantColorId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<byte>("B")
                                .HasColumnType("tinyint");

                            b1.Property<byte>("G")
                                .HasColumnType("tinyint");

                            b1.Property<byte>("R")
                                .HasColumnType("tinyint");

                            b1.HasKey("PredefinedParticipantColorId");

                            b1.ToTable("PredefinedParticipantColor");

                            b1.WithOwner()
                                .HasForeignKey("PredefinedParticipantColorId");
                        });
                });

            modelBuilder.Entity("PokerTime.Domain.Entities.Retrospective", b =>
                {
                    b.OwnsOne("PokerTime.Domain.Entities.RetrospectiveOptions", "Options", b1 =>
                        {
                            b1.Property<int>("RetrospectiveId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("MaximumNumberOfVotes")
                                .HasColumnType("int");

                            b1.HasKey("RetrospectiveId");

                            b1.ToTable("Retrospective");

                            b1.WithOwner()
                                .HasForeignKey("RetrospectiveId");
                        });

                    b.OwnsOne("PokerTime.Domain.Entities.RetrospectiveWorkflowData", "WorkflowData", b1 =>
                        {
                            b1.Property<int>("RetrospectiveId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTimeOffset>("CurrentWorkflowInitiationTimestamp")
                                .HasColumnType("datetimeoffset");

                            b1.Property<int>("CurrentWorkflowTimeLimitInMinutes")
                                .HasColumnType("int");

                            b1.HasKey("RetrospectiveId");

                            b1.ToTable("Retrospective");

                            b1.WithOwner()
                                .HasForeignKey("RetrospectiveId");
                        });

                    b.OwnsOne("PokerTime.Domain.ValueObjects.SessionIdentifier", "UrlId", b1 =>
                        {
                            b1.Property<int>("RetrospectiveId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("StringId")
                                .IsRequired()
                                .HasColumnType("varchar(32)")
                                .HasMaxLength(32)
                                .IsUnicode(false);

                            b1.HasKey("RetrospectiveId");

                            b1.HasIndex("StringId")
                                .IsUnique()
                                .HasFilter("[UrlId_StringId] IS NOT NULL");

                            b1.ToTable("Retrospective");

                            b1.WithOwner()
                                .HasForeignKey("RetrospectiveId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
