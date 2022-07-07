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

    public void OnGet(int listId)
    {
    }
}