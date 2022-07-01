using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorVue.Data;
using RazorVue.Data.Models;

namespace RazorVue.Pages.Materials;

public class DeleteModel : PageModel
{
    private readonly EditorDbContext _context;

    public DeleteModel(EditorDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Material Material { get; set; }

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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.Materials == null)
        {
            return NotFound();
        }

        var material = await _context.Materials.FindAsync(id);

        if (material != null)
        {
            Material = material;
            _context.Materials.Remove(Material);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}