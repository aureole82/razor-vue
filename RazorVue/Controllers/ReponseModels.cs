using System;
using RazorVue.Data.Models;

namespace RazorVue.Controllers;

public class SegmentResponse
{
    public int Id { get; set; }
    public TimeSpan Start { get; set; }
    public int Length { get; set; }

    public string Description { get; set; }
    public SegmentType Type { get; set; }
    public string Rights { get; set; }

    public MaterialResponse Material { get; set; }
}

public class MaterialResponse
{
    public int Id { get; set; }

    public string Description { get; set; }
}