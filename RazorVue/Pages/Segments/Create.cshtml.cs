using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorVue.Data;
using RazorVue.Data.Models;

namespace RazorVue.Pages.Segments;

public class CreateModel : PageModel
{
    private readonly EditorDbContext _context;

    public CreateModel(EditorDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Segment Segment { get; set; }

    public IActionResult OnGet()
    {
        ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Description");
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Segments.Add(Segment);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}