using System;
using System.Collections.Generic;

namespace RazorVue.Data.Models;

public class EditDecisionList
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public string Title { get; set; }
    public List<Segment> Segments { get; set; } = new();
}