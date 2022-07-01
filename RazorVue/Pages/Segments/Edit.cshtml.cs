using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorVue.Data;
using RazorVue.Data.Models;

namespace RazorVue.Pages.Segments;

public class EditModel : PageModel
{
    private readonly EditorDbContext _context;

    public EditModel(EditorDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Segment Segment { get; set; } = default!;

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
        ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Description");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Segment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SegmentExists(Segment.Id))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool SegmentExists(int id)
    {
        return _context.Segments.Any(e => e.Id == id);
    }
}