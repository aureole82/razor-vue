using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorVue.Data;

namespace RazorVue.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ListsController : ControllerBase
{
    private readonly EditorDbContext _db;
    private readonly IMapper _mapper;

    public ListsController(EditorDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    // GET: api/Lists/5/segments
    [HttpGet("{id:int}/segments")]
    public async Task<ActionResult<IEnumerable<SegmentResponse>>> GetSegments([Required] int id)
    {
        return await _db.Segments
                .AsNoTracking()
                .Where(segment => segment.ListId == id)
                .OrderBy(segment => segment.Start)
                .ProjectTo<SegmentResponse>(_mapper.ConfigurationProvider)
                .ToListAsync()
            ;
    }
}