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
    public class DetailsModel : PageModel
    {
        private readonly LabAccessSystem.Data.ApplicationDbContext _context;

        public DetailsModel(LabAccessSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Lab? Lab { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
        if (id == null)
            return NotFound();

        Lab = await _context.Labs.FirstOrDefaultAsync(m => m.Id == id);

        if (Lab == null)
            return NotFound();

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
