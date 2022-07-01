using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorVue.Data;
using RazorVue.Data.Models;

namespace RazorVue.Pages.Segments;

public class IndexModel : PageModel
{
    private readonly EditorDbContext _context;

    public IndexModel(EditorDbContext context)
    {
        _context = context;
    }

    public IList<Segment> Segments { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Segments = await _context.Segments
            .OrderBy(segment => segment.Start)
            .Include(s => s.Material).ToListAsync();
    }
}