using System;
using System.ComponentModel.DataAnnotations;

namespace RazorVue.Data.Models;

public class Segment
{
    public int Id { get; set; }
    public TimeSpan Start { get; set; }
    public int Length { get; set; }

    [Required] public string Description { get; set; }
    public SegmentType Type { get; set; }
    public string Rights { get; set; }

    public int? MaterialId { get; set; }
    public Material Material { get; set; }

    public int ListId { get; set; }
    public EditDecisionList List { get; set; }
}

public enum SegmentType
{
    New,
    Archive,
    Raw,
    Image,
    Music,
    Video
}