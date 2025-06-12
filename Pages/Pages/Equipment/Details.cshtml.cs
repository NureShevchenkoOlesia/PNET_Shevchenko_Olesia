using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabAccessSystem.Models;
using LabAccessSystem.Data;
using LabAccessSystem.Services;

namespace LabAccessSystem.Pages.Equipment
{
    public class DetailsModel : PageModel
    {
        private readonly LabAccessSystem.Data.ApplicationDbContext _context;

        public DetailsModel(LabAccessSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public LabAccessSystem.Models.Equipment Equipment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment.FirstOrDefaultAsync(m => m.Id == id);

            if (equipment is not null)
            {
                Equipment = equipment;

                return Page();
            }

            return NotFound();
        }
    }
}
