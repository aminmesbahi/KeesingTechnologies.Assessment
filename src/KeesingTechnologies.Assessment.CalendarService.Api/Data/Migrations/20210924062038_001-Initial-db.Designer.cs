﻿// <auto-generated />
using System;
using KeesingTechnologies.Assessment.CalendarService.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KeesingTechnologies.Assessment.CalendarService.Api.Data.Migrations
{
    [DbContext(typeof(EventContext))]
    [Migration("20210924062038_001-Initial-db")]
    partial class _001Initialdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("KeesingTechnologies.Assessment.CalendarService.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventOrganizer")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedByIp")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Members")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b69ab758-4324-40b8-b761-71b14cb96e8a"),
                            CreatedByIp = "151.139.128.11",
                            CreatedDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventOrganizer = "KeesingTechnologies",
                            Location = "Bangkok, Thailand",
                            Members = "[\"NXP\",\"Laxton\"]",
                            Name = "Sixth Border Management and Identity Conference",
                            Time = new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("3e8f4a34-31b0-4106-82e6-68dfbdb34c1e"),
                            CreatedByIp = "104.248.80.94",
                            CreatedDate = new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventOrganizer = "Secure ID Forum",
                            LastModifiedByIp = "104.248.80.94",
                            LastModifiedDate = new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "Riga, Latvia",
                            Members = "[\"Infotech\",\"Infineon\",\"Integrated biometrics\"]",
                            Name = "Secure ID Forum",
                            Time = new DateTime(2022, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("67a03173-624a-402d-b3e1-818d24e9dc1a"),
                            CreatedByIp = "99.86.113.17",
                            CreatedDate = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventOrganizer = "Ascential Events",
                            LastModifiedByIp = "99.86.113.17",
                            LastModifiedDate = new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "Amsterdam, Netherlands",
                            Members = "[\"Banking Circle\",\"Discover Global Network\",\"Nexi\",\"OpenPayd\",\"Solarisbank\",\"Truelayer\",\"Trustly\",\"Youlend\"]",
                            Name = "Money20/20 Europe",
                            Time = new DateTime(2021, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e4a20e6d-bee0-44cb-a1de-e558d2d3d5d8"),
                            CreatedByIp = "151.139.128.11",
                            CreatedDate = new DateTime(2021, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventOrganizer = "KeesingTechnologies",
                            Location = "Skype, Online",
                            Members = "[\"Paula van Rossen\",\"Amin Mesbahi\"]",
                            Name = "Technical Interview",
                            Time = new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("8f853347-dcb1-4b21-a77c-b2a3332ccc08"),
                            CreatedByIp = "151.139.128.11",
                            CreatedDate = new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventOrganizer = "KeesingTechnologies",
                            Location = "Skype, Online",
                            Members = "[\"Paula van Rossen\",\"Amin Mesbahi\",\"Team\",\"Managing Director\"]",
                            Name = "non-Technical Interview with team and possibly with the Managing Director",
                            Time = new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
