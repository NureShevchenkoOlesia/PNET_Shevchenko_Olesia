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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace LabAccessSystem.Pages.Equipment
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public CreateModel(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [BindProperty]
        public LabAccessSystem.Models.Equipment Equipment { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["LabId"] = new SelectList(await _context.Labs.ToListAsync(), "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Equipment.Add(Equipment);
            await _context.SaveChangesAsync();

            await LogHelper.LogAsync(_context, User.Identity?.Name ?? "Anonymous", "Create", "Equipment", Equipment.Id);

            _cache.Remove("equipment_list"); 

            return RedirectToPage("./Index");
        }
    }
}
