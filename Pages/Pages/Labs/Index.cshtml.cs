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
    public class IndexModel : PageModel
    {
        private readonly LabAccessSystem.Data.ApplicationDbContext _context;

        public IndexModel(LabAccessSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Lab> Lab { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Lab = await _context.Labs.ToListAsync();
        }
    }
}
