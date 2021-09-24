using KeesingTechnologies.Assessment.CalendarService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace KeesingTechnologies.Assessment.CalendarService.Api.Data
{
    /// <summary>
    /// Entity framework data context
    /// </summary>
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }

        public DbSet<Event> Events
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy events
            modelBuilder.Entity<Event>().HasData(
            new Event()
            {
                Id = Guid.Parse("b69ab758-4324-40b8-b761-71b14cb96e8a"),
                Name = "Sixth Border Management and Identity Conference",
                Time = new DateTime(2021, 12, 01),
                Location = "Bangkok, Thailand",
                Members = {
                    "NXP",
                    "Laxton"
                },
                EventOrganizer = "KeesingTechnologies",
                CreatedByIp = "151.139.128.11",
                CreatedDate = new DateTime(2021, 01, 01),
            },
            new Event()
            {
                Id = Guid.Parse("3e8f4a34-31b0-4106-82e6-68dfbdb34c1e"),
                Name = "Secure ID Forum",
                Time = new DateTime(2022, 05, 24),
                Location = "Riga, Latvia",
                Members = {
                    "Infotech",
                    "Infineon",
                    "Integrated biometrics"
                },
                EventOrganizer = "Secure ID Forum",
                CreatedByIp = "104.248.80.94",
                CreatedDate = new DateTime(2021, 01, 10),
                LastModifiedByIp = "104.248.80.94",
                LastModifiedDate = new DateTime(2021, 06, 10),
            },
            new Event()
            {
                Id = Guid.Parse("67a03173-624a-402d-b3e1-818d24e9dc1a"),
                Name = "Money20/20 Europe",
                Time = new DateTime(2021, 09, 21),
                Location = "Amsterdam, Netherlands",
                Members = {
                    "Banking Circle",
                    "Discover Global Network",
                    "Nexi",
                    "OpenPayd",
                    "Solarisbank",
                    "Truelayer",
                    "Trustly",
                    "Youlend"
                },
                EventOrganizer = "Ascential Events",
                CreatedByIp = "99.86.113.17",
                CreatedDate = new DateTime(2021, 01, 20),
                LastModifiedByIp = "99.86.113.17",
                LastModifiedDate = new DateTime(2021, 06, 20),
            },
            new Event()
            {
                Id = Guid.Parse("e4a20e6d-bee0-44cb-a1de-e558d2d3d5d8"),
                Name = "Technical Interview",
                Time = new DateTime(2021, 09, 30),
                Location = "Skype, Online",
                Members = {
                    "Paula van Rossen",
                    "Amin Mesbahi"
                },
                EventOrganizer = "KeesingTechnologies",
                CreatedByIp = "151.139.128.11",
                CreatedDate = new DateTime(2021, 09, 27),
            },
            new Event()
            {
                Id = Guid.Parse("8f853347-dcb1-4b21-a77c-b2a3332ccc08"),
                Name = "non-Technical Interview with team and possibly with the Managing Director",
                Time = new DateTime(2021, 10, 04),
                Location = "Skype, Online",
                Members = {
                    "Paula van Rossen",
                    "Amin Mesbahi",
                    "Team",
                    "Managing Director"
                },
                EventOrganizer = "KeesingTechnologies",
                CreatedByIp = "151.139.128.11",
                CreatedDate = new DateTime(2021, 09, 30),
            });

            modelBuilder.Entity<Event>()
    .Property(e => e.Members)
    .HasConversion(
        v => JsonSerializer.Serialize(v, null),
        v => JsonSerializer.Deserialize<List<string>>(v, null),
        new ValueComparer<ICollection<string>>(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => (ICollection<string>)c.ToList()));

            base.OnModelCreating(modelBuilder);
        }
    }
}