using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabAccessSystem.Data;
using LabAccessSystem.Models;

namespace LabAccessSystem.Pages.Labs
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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

            Lab = await _context.Labs.FindAsync(id);

            if (Lab == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var labToUpdate = await _context.Labs.FindAsync(Lab.Id);
            if (labToUpdate == null)
            {
                return NotFound();
            }

            labToUpdate.Name = Lab.Name;
            labToUpdate.Location = Lab.Location;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}
