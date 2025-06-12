using LabAccessSystem.Models;
using LabAccessSystem.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LabAccessSystem.Services;

namespace LabAccessSystem.Pages.Equipment
{
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly IMemoryCache _cache;

    public IndexModel(ApplicationDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public IList<LabAccessSystem.Models.Equipment> Equipment { get; set; } = default!;

    public async Task OnGetAsync()
{
    const string cacheKey = "equipment_list";

    if (!_cache.TryGetValue(cacheKey, out List<LabAccessSystem.Models.Equipment>? cachedEquipment))
    {
        cachedEquipment = await _context.Equipment
            .Include(e => e.Lab) 
            .ToListAsync();

        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(5));

        _cache.Set(cacheKey, cachedEquipment, cacheEntryOptions);
    }

    Equipment = cachedEquipment!;
}
}
}
