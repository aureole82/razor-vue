using System;
using RazorVue.Data.Models;

namespace RazorVue.Controllers;

public class SegmentRequest
{
    public TimeSpan Start { get; set; }
    public int Length { get; set; }

    public string Description { get; set; }
    public SegmentType Type { get; set; }
    public string Rights { get; set; }
    public int? MaterialId { get; set; }
}