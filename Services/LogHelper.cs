using LabAccessSystem.Data;
using LabAccessSystem.Models;

namespace LabAccessSystem.Services;

public static class LogHelper
{
    public static async Task LogAsync(ApplicationDbContext context, string userName, string action, string entityName, int? entityId = null)
    {
        var log = new AccessLog
        {
            UserName = userName,
            Action = action,
            EntityName = entityName,
            EntityId = entityId,
            Timestamp = DateTime.UtcNow
        };

        context.AccessLogs.Add(log);
        await context.SaveChangesAsync();
    }
}
