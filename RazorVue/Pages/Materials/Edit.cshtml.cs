using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorVue.Data;
using RazorVue.Data.Models;

namespace RazorVue.Pages.Materials;

public class EditModel : PageModel
{
    private readonly EditorDbContext _context;

    public EditModel(EditorDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Material Material { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Materials == null)
        {
            return NotFound();
        }

        var material = await _context.Materials.FirstOrDefaultAsync(m => m.Id == id);
        if (material == null)
        {
            return NotFound();
        }

        Material = material;
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

        _context.Attach(Material).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MaterialExists(Material.Id))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool MaterialExists(int id)
    {
        return _context.Materials.Any(e => e.Id == id);
    }
}