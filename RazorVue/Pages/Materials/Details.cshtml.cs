using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorVue.Data;
using RazorVue.Data.Models;

namespace RazorVue.Pages.Materials;

public class DetailsModel : PageModel
{
    private readonly EditorDbContext _context;

    public DetailsModel(EditorDbContext context)
    {
        _context = context;
    }

    public Material Material { get; set; }

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
}