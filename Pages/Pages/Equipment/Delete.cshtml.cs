using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabAccessSystem.Data;
using LabAccessSystem.Models;
using Microsoft.Extensions.Caching.Memory;
using LabAccessSystem.Services;

namespace LabAccessSystem.Pages.Equipment
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public DeleteModel(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [BindProperty]
        public LabAccessSystem.Models.Equipment Equipment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Equipment = await _context.Equipment.Include(e => e.Lab).FirstOrDefaultAsync(m => m.Id == id);

            if (Equipment == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Equipment = await _context.Equipment.FindAsync(id);

            if (Equipment != null)
            {
                _context.Equipment.Remove(Equipment);
                await _context.SaveChangesAsync();

                await LogHelper.LogAsync(_context, User.Identity?.Name ?? "Anonymous", "Delete", "Equipment", Equipment.Id);

                _cache.Remove("equipment_list"); 
            }

            return RedirectToPage("./Index");
        }
    }
}
