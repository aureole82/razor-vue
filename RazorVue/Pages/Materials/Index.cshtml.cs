using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorVue.Data;
using RazorVue.Data.Models;

namespace RazorVue.Pages.Materials;

public class IndexModel : PageModel
{
    private readonly EditorDbContext _context;

    public IndexModel(EditorDbContext context)
    {
        _context = context;
    }

    public IList<Material> Material { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Material = await _context.Materials.ToListAsync();
    }
}