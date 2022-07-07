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
public class ListsController : ControllerBase
{
    private readonly EditorDbContext _db;

    public ListsController(EditorDbContext db)
    {
        _db = db;
    }

    // GET: api/Lists/5/segments
    [HttpGet("{id:int}/segments")]
    public async Task<ActionResult<IEnumerable<Segment>>> GetSegments([Required] int id)
    {
        return await _db.Segments
                .Where(segment => segment.ListId == id)
                .Include(segment => segment.Material)
                .OrderBy(segment => segment.Start)
                .ToListAsync()
            ;
    }
}