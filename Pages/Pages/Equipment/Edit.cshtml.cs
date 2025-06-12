using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabAccessSystem.Data;
using LabAccessSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using LabAccessSystem.Services;

namespace LabAccessSystem.Pages.Equipment
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public EditModel(ApplicationDbContext context, IMemoryCache cache)
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

            ViewData["LabId"] = new SelectList(_context.Labs, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(Equipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                await LogHelper.LogAsync(_context, User.Identity?.Name ?? "Anonymous", "Edit", "Equipment", Equipment.Id);

                _cache.Remove("equipment_list"); 
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Equipment.Any(e => e.Id == Equipment.Id)) return NotFound();
                else throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
