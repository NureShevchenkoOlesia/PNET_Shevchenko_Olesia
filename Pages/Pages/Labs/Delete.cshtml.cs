using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabAccessSystem.Data;
using LabAccessSystem.Models;

namespace LabAccessSystem.Pages.Labs
{
    public class DeleteModel : PageModel
    {
        private readonly LabAccessSystem.Data.ApplicationDbContext _context;

        public DeleteModel(LabAccessSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lab Lab { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = await _context.Labs.FirstOrDefaultAsync(m => m.Id == id);

            if (lab is not null)
            {
                Lab = lab;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = await _context.Labs.FindAsync(id);
            if (lab != null)
            {
                Lab = lab;
                _context.Labs.Remove(Lab);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
