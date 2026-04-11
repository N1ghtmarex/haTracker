using Abstractions.Interfaces;
using Core.Utils;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UnitService(ApplicationDbContext dbContext) : IUnitService
{
    public async Task<Result<Unit>> GetUnitAsync(Ulid id, CancellationToken cancellationToken = default)
    {
        var unit = await dbContext.Units
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (unit != null)
        {
            return Result.Success(unit);
        }

        return Result.Failure<Unit>($"Эмодзи с идентификатором \"{id}\" не найдено!");
    }
}
