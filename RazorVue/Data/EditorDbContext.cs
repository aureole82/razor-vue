using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RazorVue.Data.Models;

namespace RazorVue.Data;

public class EditorDbContext : DbContext
{
    public EditorDbContext(DbContextOptions<EditorDbContext> options)
        : base(options)
    {
    }

    public DbSet<Material> Materials { get; set; }
    public DbSet<EditDecisionList> Lists { get; set; }
    public DbSet<Segment> Segments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Material[] materials =
        {
            // List 1.
            new()
            {
                Id = 1,
                Description = "First steps of Mountain Mike",
                ExternalReference = "4/100512274",
                OriginatingSystem = "Archive"
            },
            new()
            {
                Id = 2,
                Description = "Mountain Mike is hiking",
                ExternalReference = "4/101426827",
                OriginatingSystem = "Archive"
            },
            new()
            {
                Id = 3,
                Description = "Hiking is a new movement",
                ExternalReference = "4/101526914; 510/12/000.434.997",
                OriginatingSystem = "Archive;PreEditor"
            },
            new()
            {
                Id = 4,
                Description = "Mountain Mike takes a rest",
                ExternalReference = "4/101427138",
                OriginatingSystem = "Archive"
            },
            new()
            {
                Id = 5,
                Description = "Local mountain tours for intermediates",
                ExternalReference = "4/101536989; 510/12/000.434.998",
                OriginatingSystem = "Archive;PreEditor"
            },
            new()
            {
                Id = 7,
                Description = "Say goodbye to Mountain Mike",
                ExternalReference = "4/101429299",
                OriginatingSystem = "Archive"
            },
            // List 2.
            new()
            {
                Id = 12,
                Description = "Debate: Exhausting work / low salary",
                ExternalReference = "4/101904594; 510/12/000.435.014",
                OriginatingSystem = "Archive;PreEditor"
            },
            new()
            {
                Id = 15,
                Description = "Clip: Critical importance of hospital staff",
                ExternalReference = "4/101904649; 510/12/000.435.074",
                OriginatingSystem = "Archive;PreEditor"
            }
        };
        modelBuilder.Entity<Material>().HasData(materials);

        const int list1Id = 1;
        const int list2Id = 2;
        EditDecisionList[] lists =
        {
            new()
            {
                Id = list1Id,
                BroadcastDay = new DateTime(2022, 7, 1),
                BroadcastTitle = "Local News @ 6pm",
                Title = "Mountain Mike",
                CostCenter = "4731"
            },
            new()
            {
                Id = list2Id,
                BroadcastDay = new DateTime(2022, 7, 1),
                BroadcastTitle = "Regional News @ 8pm",
                Title = "Medicare staff shortage",
                CostCenter = "8420"
            }
        };
        modelBuilder.Entity<EditDecisionList>().HasData(lists);

        Segment[] segments =
        {
            // List1.
            new()
            {
                Id = 1,
                Description = "Mountain Mike tells about the beginning",
                Type = SegmentType.Archive,
                Length = 12,
                OriginDescription = "CBC",
                OriginBroadcastDay = new DateTime(2021, 2, 5),
                Rights = "w/o",
                ListId = list1Id
            },
            new()
            {
                Id = 2,
                Description = "Mountain Mike tells about the beginning",
                Type = SegmentType.New,
                Length = 24,
                Origin = "",
                OriginDescription = "CBC",
                Rights = "w/o",
                ListId = list1Id
            },
            new()
            {
                Id = 3,
                Description = "Everybody loves hiking",
                Type = SegmentType.Archive,
                Length = 18,
                OriginBroadcastDay = new DateTime(2021, 2, 5),
                Rights = "Property of the content group, usage allowed",
                ListId = list1Id
            },
            new()
            {
                Id = 4,
                Description = "Take a break, Mike",
                Type = SegmentType.New,
                Length = 6,
                Rights = "w/o",
                ListId = list1Id
            },
            new()
            {
                Id = 5,
                Description = "Local mountain tours",
                Type = SegmentType.Archive,
                Length = 18,
                OriginDescription = "CBC",
                OriginBroadcastDay = new DateTime(2021, 2, 5),
                Rights = "Property of the local hiking club, usage allowed",
                ListId = list1Id
            },
            new()
            {
                Id = 6,
                Description = "Map of local mountain tours",
                Type = SegmentType.Image,
                Start = TimeSpan.FromSeconds(12 + 24 + 18 + 6 + 3),
                Length = 12,
                OriginDescription = "LoMoTo",
                OriginBroadcastDay = new DateTime(1993, 12, 15),
                Rights = "Property of the local hiking club, usage allowed only for current broadcast",
                ListId = list1Id
            },
            new()
            {
                Id = 7,
                Description = "Time to say goodbye",
                Type = SegmentType.New,
                Length = 6,
                OriginDescription = "CBC",
                Rights = "w/o",
                ListId = list1Id
            },
            // List 2.
            new()
            {
                Id = 10,
                Description = "Unemployment in health care",
                Type = SegmentType.New,
                Length = 82,
                OriginDescription = "CBC",
                Rights = "w/o",
                ListId = list2Id
            },
            new()
            {
                Id = 11,
                Description = "Nurse in working clothes",
                Type = SegmentType.Archive,
                Length = 8,
                OriginDescription = "CBC",
                OriginBroadcastDay = new DateTime(2020, 2, 28),
                Rights = "w/o",
                ListId = list2Id
            },
            new()
            {
                Id = 12,
                Description = "Nurse with patient",
                Type = SegmentType.Image,
                Length = 10,
                OriginDescription = "CBC",
                OriginBroadcastDay = new DateTime(2020, 2, 28),
                Rights = "Personal rights of patient",
                ListId = list2Id
            },
            new()
            {
                Id = 13,
                Description = "Vocational medicare training",
                Type = SegmentType.Image,
                Length = 11,
                Rights = "Unknown",
                ListId = list2Id
            },
            new()
            {
                Id = 14,
                Description = "Medicare job offers raises",
                Type = SegmentType.Image,
                Length = 6,
                Rights = "Unknown",
                ListId = list2Id
            },
            new()
            {
                Id = 15,
                Description = "Union's march",
                Type = SegmentType.Archive,
                Length = 39,
                OriginDescription = "CBC",
                OriginBroadcastDay = new DateTime(2020, 2, 28),
                Rights = "w/o",
                ListId = list2Id
            },
            new()
            {
                Id = 16,
                Description = "Transition",
                Type = SegmentType.New,
                Length = 1,
                OriginDescription = "CBC",
                Rights = "w/o",
                ListId = list2Id
            },
            new()
            {
                Id = 17,
                Description = "Latest voices about staff shortage",
                Type = SegmentType.New,
                Length = 57,
                OriginDescription = "CBC",
                Rights = "w/o",
                ListId = list2Id
            },
            new()
            {
                Id = 18,
                Description = "Overloaded board crashes down in job center",
                Type = SegmentType.Raw,
                Length = 3,
                Rights = "Unknown",
                ListId = list2Id
            }
        };
        modelBuilder.Entity<Segment>().HasData(segments);

        // Assign segments to materials (just by matching the primary keys).
        foreach (var material in materials)
        {
            var segment = segments.FirstOrDefault(segment => segment.Id == material.Id);
            if (segment == null)
                continue;
            segment.MaterialId = material.Id;
        }

        // Calculate the start timestamps of each segment in a list.
        foreach (var segmentsOfAList in segments.GroupBy(segment => segment.ListId))
        {
            var current = TimeSpan.Zero;
            foreach (var segment in segmentsOfAList.Where(segment => segment.Start == default))
            {
                segment.Start = current;
                current = current.Add(TimeSpan.FromSeconds(segment.Length));
            }

            foreach (var segment in segmentsOfAList
                         .Where(segment => segment.Origin == default && segment.OriginBroadcastDay.HasValue))
            {
                segment.Origin = @$"Story: {segment.Description} | 
Program: {(segment.OriginBroadcastDay.Value.Year < 2021 ? "HilariousTV" : "Gossip @ 4pm")} | 
{segment.OriginBroadcastDay:d}";
            }

            var list = lists.First(list => list.Id == segmentsOfAList.Key);
            list.Duration = current;
        }
    }
}