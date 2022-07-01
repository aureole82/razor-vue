using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorVue.Data;
using RazorVue.Data.Models;

namespace RazorVue.Pages.Lists;

public class IndexModel : PageModel
{
    private readonly EditorDbContext _context;

    public IndexModel(EditorDbContext context)
    {
        _context = context;
    }

    public IList<EditDecisionList> Lists { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Lists = await _context.Lists.ToListAsync();
    }
}