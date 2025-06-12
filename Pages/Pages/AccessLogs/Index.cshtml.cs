using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabAccessSystem.Data;
using LabAccessSystem.Models;

namespace LabAccessSystem.Pages.AccessLogs
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<AccessLog> Logs { get; set; } = new();

        public async Task OnGetAsync()
        {
            Logs = await _context.AccessLogs
                .OrderByDescending(l => l.Timestamp)
                .ToListAsync();
        }
    }
}
