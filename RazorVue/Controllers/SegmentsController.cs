using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    private readonly IMapper _mapper;

    public SegmentsController(EditorDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    // GET: api/Segments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Segment>> GetSegment(int id)
    {
        var segment = await _db.Segments
                .AsNoTracking()
                .Where(segment => segment.Id == id)
                .ProjectTo<SegmentResponse>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync()
            ;

        return segment == null ? NotFound() : Ok(segment);
    }

    // PUT: api/Segments/5
    [HttpPut("{id}")]
    public async Task<ActionResult<SegmentResponse>> PutSegment(int id, SegmentRequest request)
    {
        if (id == default)
        {
            return BadRequest();
        }

        var stored = await _db.Segments.FindAsync(id);
        if (stored == null)
        {
            NotFound();
        }

        _mapper.Map(request, stored);
        await _db.SaveChangesAsync();

        if (stored.MaterialId != default)
        {
            stored.Material = await _db.Materials.FindAsync(stored.MaterialId);
        }

        return Ok(_mapper.Map<SegmentResponse>(stored));
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