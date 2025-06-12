using LabAccessSystem.Data;
using LabAccessSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LabAccessSystem.Pages.Assignments
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assignment Assignment { get; set; }

        public SelectList EmployeesSelectList { get; set; }
        public SelectList EquipmentSelectList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            EmployeesSelectList = new SelectList(await _context.Employees.ToListAsync(), "Id", "FullName");
            EquipmentSelectList = new SelectList(await _context.Equipment.ToListAsync(), "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Assignments.Add(Assignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Assignments/Index");
        }
    }
}
