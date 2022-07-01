using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorVue.Data;
using RazorVue.Data.Models;

namespace RazorVue.Pages.Segments;

public class DetailsModel : PageModel
{
    private readonly EditorDbContext _context;

    public DetailsModel(EditorDbContext context)
    {
        _context = context;
    }

    public Segment Segment { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Segments == null)
        {
            return NotFound();
        }

        var segment = await _context.Segments.FirstOrDefaultAsync(m => m.Id == id);
        if (segment == null)
        {
            return NotFound();
        }

        Segment = segment;
        return Page();
    }
}