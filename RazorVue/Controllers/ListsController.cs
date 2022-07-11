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
    public async Task<ActionResult<ListResponse>> GetSegments([Required] int id)
    {
        var list = await _db.Lists
                .AsNoTracking()
                .Where(list => list.Id == id)
                .ProjectTo<ListResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync()
            ;
        if (list == default)
        {
            return NotFound();
        }

        list.Segments = list.Segments
                .OrderBy(segment => segment.Start)
                .ToList()
            ;

        return list;
    }
}