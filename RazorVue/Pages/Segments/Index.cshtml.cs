using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorVue.Data;

namespace RazorVue.Pages.Segments;

public class IndexModel : PageModel
{
    private readonly EditorDbContext _context;

    public IndexModel(EditorDbContext context)
    {
        _context = context;
    }

    public async Task OnGet()
    {
        ViewData["Materials"] = await _context.Materials
                .Select(material => new SelectListItem(material.Description, $"{material.Id}"))
                .ToListAsync()
            ;
    }
}