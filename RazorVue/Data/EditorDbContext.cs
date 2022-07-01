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
        var list = new EditDecisionList
        {
            Id = 1,
            Start = new DateTime(2022, 7, 1, 19, 14, 23),
            Title = "Mountain Mike"
        };

        modelBuilder.Entity<EditDecisionList>().HasData(list);
        Segment[] segments =
        {
            new()
            {
                Id = 1,
                Description = "Mountain Mike tells about the beginning",
                Type = SegmentType.Archive,
                Length = 12,
                MaterialId = 1,
                Rights = "w/o",
                ListId = 1
            },
            new()
            {
                Id = 2,
                Description = "Mountain Mike tells about the beginning",
                Type = SegmentType.New,
                Length = 24,
                MaterialId = 2,
                Rights = "w/o",
                ListId = 1
            },
            new()
            {
                Id = 3,
                Description = "Everybody loves hiking",
                Type = SegmentType.Archive,
                Length = 18,
                MaterialId = 3,
                Rights = "Property of the content group, usage allowed",
                ListId = 1
            },
            new()
            {
                Id = 4,
                Description = "Take a break, Mike",
                Type = SegmentType.New,
                Length = 6,
                MaterialId = 4,
                Rights = "w/o",
                ListId = 1
            },
            new()
            {
                Id = 5,
                Description = "Local mountain tours",
                Type = SegmentType.Archive,
                Length = 18,
                MaterialId = 5,
                Rights = "Property of the local hiking club, usage allowed",
                ListId = 1
            },
            new()
            {
                Id = 6,
                Description = "Map of local mountain tours",
                Type = SegmentType.Image,
                Start = TimeSpan.FromSeconds(12 + 24 + 18 + 6 + 3),
                Length = 12,
                Rights = "Property of the local hiking club, usage allowed only for current broadcast",
                ListId = 1
            },
            new()
            {
                Id = 7,
                Description = "Time to say goodbye",
                Type = SegmentType.New,
                Length = 6,
                MaterialId = 7,
                Rights = "w/o",
                ListId = 1
            }
        };
        var current = TimeSpan.Zero;
        foreach (var segment in segments.Where(segment => segment.Start == default))
        {
            segment.Start = current;
            current = current.Add(TimeSpan.FromSeconds(segment.Length));
        }


        modelBuilder.Entity<Segment>().HasData(segments);
        modelBuilder.Entity<Material>().HasData(
            new Material
            {
                Id = 1,
                Description = "First steps of Mountain Mike",
                ExternalReference = "4/100512274",
                OriginatingSystem = "Archive"
            }, new Material
            {
                Id = 2,
                Description = "Mountain Mike is hiking",
                ExternalReference = "4/101426827",
                OriginatingSystem = "Archive"
            }, new Material
            {
                Id = 3,
                Description = "Hiking is a new movement",
                ExternalReference = "4/101526914; 510/12/000.434.997",
                OriginatingSystem = "Archive;PreEditor"
            }, new Material
            {
                Id = 4,
                Description = "Mountain Mike takes a rest",
                ExternalReference = "4/101427138",
                OriginatingSystem = "Archive"
            },
            new Material
            {
                Id = 5,
                Description = "Local mountain tours for intermediates",
                ExternalReference = "4/101536989; 510/12/000.434.998",
                OriginatingSystem = "Archive;PreEditor"
            }, new Material
            {
                Id = 7,
                Description = "Say goodbye to Mountain Mike",
                ExternalReference = "4/101429299",
                OriginatingSystem = "Archive"
            });
    }
}