using System;
using System.Collections.Generic;

namespace RazorVue.Data.Models;

public class EditDecisionList
{
    public int Id { get; set; }
    public string BroadcastTitle { get; set; }
    public DateTime BroadcastDay { get; set; }
    public string Title { get; set; }
    public TimeSpan Duration { get; set; }
    public string CostCenter { get; set; }

    public List<Segment> Segments { get; set; } = new();
}