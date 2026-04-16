using Abstractions.Interfaces;
using Core.Utils;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CompletionService(ApplicationDbContext dbContext) : ICompletionService
{
    public async Task<Completion?> GetTaskCompletionByDateAsync(Ulid id, DateTimeOffset date, CancellationToken cancellationToken = default)
    {
        return await dbContext.Completions
            .SingleOrDefaultAsync(x => x.TaskId == id && x.Date.Date == date.Date, cancellationToken);
    }
}
