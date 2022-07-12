using System;
using System.ComponentModel.DataAnnotations;
using RazorVue.Data.Models;

namespace RazorVue.Controllers;

public class SegmentRequest
{
    public TimeSpan Start { get; set; }
    public int Length { get; set; }
    [Required] [MinLength(10)] public string Description { get; set; }
    public SegmentType Type { get; set; }
    public string Origin { get; set; }
    public DateTime? OriginBroadcastDay { get; set; }
    public string OriginDescription { get; set; }
    public string Rights { get; set; }
    public int? MaterialId { get; set; }
}