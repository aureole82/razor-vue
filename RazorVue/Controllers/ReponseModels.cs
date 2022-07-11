using System;
using System.Collections.Generic;
using RazorVue.Data.Models;

namespace RazorVue.Controllers;

public class ListResponse
{
    public int Id { get; set; }
    public string BroadcastTitle { get; set; }
    public DateTime BroadcastDay { get; set; }
    public string Title { get; set; }
    public TimeSpan Duration { get; set; }
    public string CostCenter { get; set; }

    public List<SegmentResponse> Segments { get; set; } = new();
}

public class SegmentResponse
{
    public int Id { get; set; }
    public TimeSpan Start { get; set; }
    public int Length { get; set; }
    public string Description { get; set; }
    public SegmentType Type { get; set; }
    public string Rights { get; set; }

    public int? MaterialId { get; set; }
    public string MaterialDescription { get; set; }
}