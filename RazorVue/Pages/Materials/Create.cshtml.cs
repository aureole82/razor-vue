using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorVue.Data;
using RazorVue.Data.Models;

namespace RazorVue.Pages.Materials;

public class CreateModel : PageModel
{
    private readonly EditorDbContext _context;

    public CreateModel(EditorDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Material Material { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Materials.Add(Material);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}