using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorVue.Data;
using RazorVue.Data.Models;

namespace RazorVue.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SegmentsController : ControllerBase
{
    private readonly EditorDbContext _db;

    public SegmentsController(EditorDbContext db)
    {
        _db = db;
    }

    // GET: api/Segments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Segment>> GetSegment(int id)
    {
        var segment = await _db.Segments.FindAsync(id);

        return segment == null ? NotFound() : segment;
    }

    // PUT: api/Segments/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSegment(int id, Segment segment)
    {
        if (id != default)
        {
            return BadRequest();
        }

        _db.Update(segment);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    // POST: api/Segments
    [HttpPost]
    public async Task<ActionResult<Segment>> PostSegment(Segment segment)
    {
        await _db.Segments.AddAsync(segment);
        await _db.SaveChangesAsync();

        return CreatedAtAction("GetSegment", new { id = segment.Id }, segment);
    }

    // DELETE: api/Segments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSegment(int id)
    {
        _db.Segments.Remove(new Segment { Id = id });
        await _db.SaveChangesAsync();

        return NoContent();
    }
}